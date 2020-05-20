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
        IRequestHandler<CadastrarDistribuicaoPorAtivoCommand, bool>,
        IRequestHandler<AlterarDistribuicaoPorAtivoCommand, bool>,
        IRequestHandler<RecalcularDistribuicaoPorAtivoCommand, bool>
    {
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

        public async Task<bool> Handle(CadastrarDistribuicaoPorAtivoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.AtivoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            if (AtivoJaCadastrado(request.AtivoId))
            {
                _handlerBase.PublishNotification("Este ativo já possuí um percentual de distribuição definido");
            }

            _distribuicaoRepositorio.Insert(_mapper.Map<DistribuicaoPorAtivo>(request));
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }


        public async Task<bool> Handle(AlterarDistribuicaoPorAtivoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;


            if (AtivoJaCadastrado(request.AtivoId, request.Id))
            {
                _handlerBase.PublishNotification("O novo ativo selecionado já possuí um percentual de distribuição definido");
                return false;
            }

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.AtivoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            return await Update(_mapper.Map<DistribuicaoPorAtivo>(request)); ;
        }

        public async Task<bool> Handle(RecalcularDistribuicaoPorAtivoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorAtivo> distribuicoes = _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == request.UsuarioId).Result.ToList();
            var valor_total = _aporteRepository.ObterTotalAplicado(request.UsuarioId).Result;

            foreach (var item in distribuicoes)
            {
                var valorTotalPorAtivo = _aporteRepository.ObterTotalAplicadoPorAtivo(item.AtivoId, request.UsuarioId).Result;
                item.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorAtivo, valor_total);
                item.AtualizarOrientacao();
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

    }
}