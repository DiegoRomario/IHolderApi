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
    public class DistribuicaoPorAtivoHandler :
        IRequestHandler<AlterarDistribuicaoPorAtivoCommand, bool>,
        IRequestHandler<RecalcularDistribuicaoPorAtivoCommand, bool>,
        IRequestHandler<DividirDistribuicaoPorAtivoCommand, bool>
    {
        private const int PERCENTUAL_MAXIMO = 100;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorAtivo> _distribuicaoRepositorio;
        private readonly IAporteRepository _aporteRepository;
        private readonly IHandlerBase _handlerBase;

        public DistribuicaoPorAtivoHandler(IMapper mapper,
            IRepositoryBase<DistribuicaoPorAtivo> distribuicaoPorAtivoRepository,
            IAporteRepository aporteRepository,
            IHandlerBase handlerBase)
        {
            _mapper = mapper;
            _distribuicaoRepositorio = distribuicaoPorAtivoRepository;
            _aporteRepository = aporteRepository;
            _handlerBase = handlerBase;
        }


        public async Task<bool> Handle(AlterarDistribuicaoPorAtivoCommand request, CancellationToken cancellationToken)
        {

            if (AtivoJaCadastrado(request.TipoDistribuicaoId, request.Id))
                _handlerBase.PublishNotification("O novo ativo selecionado já possuí um percentual de distribuição definido");

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.TipoDistribuicaoId, request.PercentualObjetivo))
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");

            if (_handlerBase.HasNotification())
                return false;

            return await Update(_mapper.Map<DistribuicaoPorAtivo>(request)); ;
        }

        public async Task<bool> Handle(RecalcularDistribuicaoPorAtivoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorAtivo> distribuicoes = _distribuicaoRepositorio.GetManyBy(where: d => d.UsuarioId == request.UsuarioId, d => d.Ativo).Result.ToList();
            var valorTotalGeral = _aporteRepository.ObterTotalAplicado(request.UsuarioId).Result;

            foreach (var item in distribuicoes)
            {
                var valorTotalPorAtivo = _aporteRepository.ObterTotalAplicadoPorAtivo(item.AtivoId, request.UsuarioId).Result;
                item.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorAtivo, valorTotalGeral);
                item.AtualizarOrientacao(valorTotalPorAtivo, valorTotalGeral);
                await Update(item);
            }

            return true;
        }


        private async Task<bool> Update(DistribuicaoPorAtivo entity)
        {
            _distribuicaoRepositorio.Update(entity);
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private bool PercentualObjetivoAcumuladoUltrapasa100PorCento(Guid AtivoId, decimal percentualObjetivo, Nullable<Guid> distribuicaoId = null)
        {
            decimal percentualAcumulado = _distribuicaoRepositorio.GetManyBy(d => d.AtivoId != AtivoId && d.Id != distribuicaoId).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo > 100;
        }

        private bool AtivoJaCadastrado(Guid AtivoId, Nullable<Guid> distribuicaoId = null)
        {
            return _distribuicaoRepositorio.GetBy(d => d.AtivoId == AtivoId && d.Id != distribuicaoId).Result != null;
        }

        public async Task<bool> Handle(DividirDistribuicaoPorAtivoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorAtivo> distribuicoes = ObterDistribuicoesAtivosCadastrados(request.UsuarioId); 

            if (request.SomenteItensEmCarteira)
                await AlterarDistribuicoesAtivosEmCarteira(request, distribuicoes);
            else
                await AlterarDistribuicoesAtivosCadastrados(distribuicoes);

            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private async Task AlterarDistribuicoesAtivosCadastrados(List<DistribuicaoPorAtivo> distribuicoes)
        {
            int percentualDivisao = PERCENTUAL_MAXIMO / distribuicoes.Count();

            foreach (var distribuicao in distribuicoes)
            {
                distribuicao.Valores.AtualizarPercentualObjetivo(percentualDivisao);
                await Update(distribuicao);
            }
        }
        private async Task AlterarDistribuicoesAtivosEmCarteira(DividirDistribuicaoPorAtivoCommand request, List<DistribuicaoPorAtivo> distribuicoes)
        {
            List<DistribuicaoPorAtivo> distribuicoesCarteira = ObterDistribuicoesAtivosEmCarteira(request.UsuarioId);
            int percentualDivisao = PERCENTUAL_MAXIMO / distribuicoesCarteira.Count();

            foreach (var distribuicao in distribuicoes)
            {   if (distribuicoesCarteira.Where(x => x.AtivoId == distribuicao.AtivoId).Any())
                    distribuicao.Valores.AtualizarPercentualObjetivo(percentualDivisao);
                else
                    distribuicao.Valores.AtualizarPercentualObjetivo(0);
                await Update(distribuicao);
            }
        }

        private List<DistribuicaoPorAtivo> ObterDistribuicoesAtivosEmCarteira(Guid usuarioId)
        {
            IEnumerable<Guid> ativosEmCarteira = _aporteRepository.GetManyBy(where: a => a.UsuarioId == usuarioId).Result.Distinct(new AtivoAporteComparer()).Select(a => a.AtivoId);
            List<DistribuicaoPorAtivo> distribuicoes =
            _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == usuarioId && ativosEmCarteira.Contains(d.AtivoId)).Result.ToList();

            return distribuicoes;
        }

        private List<DistribuicaoPorAtivo> ObterDistribuicoesAtivosCadastrados(Guid usuarioId)
        {
            return _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == usuarioId).Result.ToList();
        }

        

    }
}