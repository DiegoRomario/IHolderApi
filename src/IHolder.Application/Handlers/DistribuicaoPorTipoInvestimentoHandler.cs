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

            if (PercentualObjetivoAcumulado(request.TipoInvestimentoId, request.PercentualObjetivo) > 100)
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }                

            _distribuicaoRepositorio.Insert(_mapper.Map<DistribuicaoPorTipoInvestimento>(request));
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AlterarDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;            
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

        private decimal PercentualObjetivoAcumulado(Guid id, decimal percentualObjetivo)
        {
            decimal percentualAcumulado = _distribuicaoRepositorio.GetManyBy(d => d.Id != id).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo;
        }

        private async Task<bool> Update(DistribuicaoPorTipoInvestimento entity)
        {
            _distribuicaoRepositorio.Update(entity);
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

    }
}
