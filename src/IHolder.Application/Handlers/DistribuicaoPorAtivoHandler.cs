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
        private readonly IRepositoryBase<Ativo> _ativoRepositorio;
        private readonly IAporteRepository _aporteRepository;
        private readonly IHandlerBase _handlerBase;

        public DistribuicaoPorAtivoHandler(IMapper mapper,
            IRepositoryBase<DistribuicaoPorAtivo> distribuicaoPorAtivoRepository,
            IAporteRepository aporteRepository,
            IHandlerBase handlerBase, IRepositoryBase<Ativo> ativoRepositorio)
        {
            _mapper = mapper;
            _distribuicaoRepositorio = distribuicaoPorAtivoRepository;
            _aporteRepository = aporteRepository;
            _handlerBase = handlerBase;
            _ativoRepositorio = ativoRepositorio;
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
            List<DistribuicaoPorAtivo> distribuicoes = _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == request.UsuarioId).Result.ToList();
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
            List<DistribuicaoPorAtivo> distribuicoes =
                request.somenteAtivosEmCarteira ? ObterDistribuicoesAtivosEmCarteira(request.UsuarioId)
                                                : ObterDistribuicoesAtivosCadastrados(request.UsuarioId);
            int quantidadeAtivos = distribuicoes.Count();
            int percentualDivisao = PERCENTUAL_MAXIMO / quantidadeAtivos;

            foreach (var distribuicao in distribuicoes)
            {
                distribuicao.Valores.AtualizarPercentualObjetivo(percentualDivisao);
                await Update(distribuicao);
            }

            return await _distribuicaoRepositorio.UnitOfWork.Commit();
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

        public class AtivoAporteComparer : IEqualityComparer<Aporte>
        {
            public bool Equals(Aporte x, Aporte y)
            {
                return x.Id == y.Id;
            }

            int IEqualityComparer<Aporte>.GetHashCode(Aporte aporte)
            {
                return aporte.Id.GetHashCode();
            }
        }

    }
}