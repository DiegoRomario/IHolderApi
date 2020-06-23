using AutoMapper;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Handlers
{
    public class DistribuicaoPorTipoInvestimentoHandler :
        IRequestHandler<AlterarDistribuicaoPorTipoInvestimentoCommand, bool>,
        IRequestHandler<RecalcularDistribuicaoPorTipoInvestimentoCommand, bool>,
        IRequestHandler<DividirDistribuicaoPorTipoInvestimentoCommand, bool>
    {
        private const decimal PERCENTUAL_MAXIMO = 100;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorTipoInvestimento> _distribuicaoRepositorio;
        private readonly IAtivoEmCarteiraRepository _AtivoEmCarteiraRepository;
        private readonly IHandlerBase _handlerBase;

        public DistribuicaoPorTipoInvestimentoHandler(IMapper mapper,
            IRepositoryBase<DistribuicaoPorTipoInvestimento> distribuicaoPorTipoInvestimentoRepository,
            IAtivoEmCarteiraRepository AtivoEmCarteiraRepository,
            IHandlerBase handlerBase)
        {
            _mapper = mapper;
            _distribuicaoRepositorio = distribuicaoPorTipoInvestimentoRepository;
            _AtivoEmCarteiraRepository = AtivoEmCarteiraRepository;
            _handlerBase = handlerBase;
        }

        public async Task<bool> Handle(AlterarDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {

            if (TipoInvestimentoJaCadastrado(request.TipoDistribuicaoId, request.Id))
            {
                _handlerBase.PublishNotification("O novo tipo de investimento selecionado já possuí um percentual de distribuição definido");
                return false;
            }

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.TipoDistribuicaoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            return await Update(_mapper.Map<DistribuicaoPorTipoInvestimento>(request)); ;
        }

        public async Task<bool> Handle(RecalcularDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorTipoInvestimento> distribuicoes = _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == request.UsuarioId).Result.ToList();
            var valor_total = _AtivoEmCarteiraRepository.ObterTotalAplicado(request.UsuarioId).Result;

            foreach (var item in distribuicoes)
            {
                var valorTotalPorTipoInvestimento = _AtivoEmCarteiraRepository.ObterTotalAplicadoPorTipoInvestimento(item.TipoInvestimentoId, request.UsuarioId).Result;
                item.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorTipoInvestimento, valor_total);
                item.AtualizarOrientacao(valorTotalPorTipoInvestimento, valor_total);
                await Update(item);
            }

            return true;
        }


        private async Task<bool> Update(DistribuicaoPorTipoInvestimento entity)
        {
            _distribuicaoRepositorio.Update(entity);
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private bool PercentualObjetivoAcumuladoUltrapasa100PorCento(Guid TipoInvestimentoId, decimal percentualObjetivo, Nullable<Guid> distribuicaoId = null)
        {
            decimal percentualAcumulado = _distribuicaoRepositorio.GetManyBy(d => d.TipoInvestimentoId != TipoInvestimentoId && d.Id != distribuicaoId).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo > 100;
        }

        private bool TipoInvestimentoJaCadastrado(Guid tipoInvestimentoId, Nullable<Guid> distribuicaoId = null)
        {
            return _distribuicaoRepositorio.GetBy(d => d.TipoInvestimentoId == tipoInvestimentoId && d.Id != distribuicaoId).Result != null;
        }
        public async Task<bool> Handle(DividirDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorTipoInvestimento> distribuicoes = ObterDistribuicoesTipoInvestimentosCadastrados(request.UsuarioId);

            if (request.SomenteItensEmCarteira)
                await AlterarDistribuicoesTipoInvestimentosEmCarteira(request, distribuicoes);
            else
                await AlterarDistribuicoesTipoInvestimentosCadastrados(distribuicoes);

            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private async Task AlterarDistribuicoesTipoInvestimentosCadastrados(List<DistribuicaoPorTipoInvestimento> distribuicoes)
        {
            decimal percentualDivisao = distribuicoes.Count() > 0 ? (PERCENTUAL_MAXIMO / distribuicoes.Count()) : 0;

            foreach (var distribuicao in distribuicoes)
            {
                distribuicao.Valores.AtualizarPercentualObjetivo(percentualDivisao);
                await Update(distribuicao);
            }
        }
        private async Task AlterarDistribuicoesTipoInvestimentosEmCarteira(DividirDistribuicaoPorTipoInvestimentoCommand request, List<DistribuicaoPorTipoInvestimento> distribuicoes)
        {
            List<DistribuicaoPorTipoInvestimento> distribuicoesCarteira = ObterDistribuicoesTipoInvestimentosEmCarteira(request.UsuarioId);
            decimal percentualDivisao = distribuicoesCarteira.Count() > 0 ?  PERCENTUAL_MAXIMO / distribuicoesCarteira.Count() : 0;

            foreach (var distribuicao in distribuicoes)
            {
                if (distribuicoesCarteira.Where(x => x.TipoInvestimentoId == distribuicao.TipoInvestimentoId).Any())
                    distribuicao.Valores.AtualizarPercentualObjetivo(percentualDivisao);
                else
                    distribuicao.Valores.AtualizarPercentualObjetivo(0);
                await Update(distribuicao);
            }
        }

        private List<DistribuicaoPorTipoInvestimento> ObterDistribuicoesTipoInvestimentosEmCarteira(Guid usuarioId)
        {
            IEnumerable<Guid> TipoInvestimentosEmCarteira = _AtivoEmCarteiraRepository.GetManyBy(where: a => a.UsuarioId == usuarioId, a => a.Ativo, a=> a.Ativo.Produto, a => a.Ativo.Produto.TipoInvestimento).Result.Distinct(new TipoInvestimentoAtivoEmCarteiraComparer()).Select(a => a.Ativo.Produto.TipoInvestimentoId) ;
            List<DistribuicaoPorTipoInvestimento> distribuicoes =
            _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == usuarioId && TipoInvestimentosEmCarteira.Contains(d.TipoInvestimentoId)).Result.ToList();
            return distribuicoes;
        }

        private List<DistribuicaoPorTipoInvestimento> ObterDistribuicoesTipoInvestimentosCadastrados(Guid usuarioId)
        {
            return _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == usuarioId).Result.ToList();
        }



    }
}