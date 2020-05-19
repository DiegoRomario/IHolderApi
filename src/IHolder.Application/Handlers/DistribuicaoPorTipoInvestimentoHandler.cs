﻿using AutoMapper;
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
        IRequestHandler<CadastrarDistribuicaoPorTipoInvestimentoCommand, bool>,
        IRequestHandler<AlterarDistribuicaoPorTipoInvestimentoCommand, bool>,
        IRequestHandler<RecalcularDistribuicaoPorTipoInvestimentoCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorTipoInvestimento> _distribuicaoRepositorio;
        private readonly IAporteRepository _aporteRepository;
        private readonly IHandlerBase _handlerBase;

        public DistribuicaoPorTipoInvestimentoHandler(IMapper mapper,
            IRepositoryBase<DistribuicaoPorTipoInvestimento> distribuicaoPorTipoInvestimentoRepository,
            IAporteRepository aporteRepository,
            IHandlerBase handlerBase)
        {
            _mapper = mapper;
            _distribuicaoRepositorio = distribuicaoPorTipoInvestimentoRepository;
            _aporteRepository = aporteRepository;
            _handlerBase = handlerBase;
        }

        public async Task<bool> Handle(CadastrarDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.TipoInvestimentoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            if (TipoInvestimentoJaCadastrado(request.TipoInvestimentoId))
            {
                _handlerBase.PublishNotification("Este tipo de investimento já possuí um percentual de distribuição definido");
            }

            _distribuicaoRepositorio.Insert(_mapper.Map<DistribuicaoPorTipoInvestimento>(request));
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private bool PercentualObjetivoAcumuladoUltrapasa100PorCento(Guid TipoInvestimentoId, decimal percentualObjetivo )
        {
            decimal percentualAcumulado = _distribuicaoRepositorio.GetManyBy(d => d.TipoInvestimentoId != TipoInvestimentoId).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo > 100;
        }

        public async Task<bool> Handle(AlterarDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;

            if (PercentualObjetivoAcumuladoUltrapasa100PorCento(request.TipoInvestimentoId, request.PercentualObjetivo))
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }


            if (!TipoInvestimentoJaCadastrado(request.TipoInvestimentoId))
            {
                _handlerBase.PublishNotification("Distribuição por tipo de investimento não encontrada");
                return false;
            }


            return await Update(_mapper.Map<DistribuicaoPorTipoInvestimento>(request)); ;
        }

        public async Task<bool> Handle(RecalcularDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorTipoInvestimento> distribuicoes = _distribuicaoRepositorio.GetManyBy(d => d.UsuarioId == request.UsuarioId).Result.ToList();
            var valor_total = _aporteRepository.ObterTotalAplicado(request.UsuarioId).Result;

            foreach (var item in distribuicoes)
            {
                var valorTotalPorTipoInvestimento = _aporteRepository.ObterTotalAplicadoPorTipoInvestimento(item.TipoInvestimentoId, request.UsuarioId).Result;
                item.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorTipoInvestimento, valor_total);
                item.AtualizarOrientacao();
                await Update(item);
            }

            return true;
        }


        private async Task<bool> Update(DistribuicaoPorTipoInvestimento entity)
        {
            _distribuicaoRepositorio.Update(entity);
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        private bool TipoInvestimentoJaCadastrado(Guid tipoInvestimentoId)
        {
            return _distribuicaoRepositorio.GetBy(d => d.TipoInvestimentoId == tipoInvestimentoId).Result != null;
        }

    }
}