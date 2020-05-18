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

            if (PercentualObjetivoAcumulado(request.AtivoId, request.PercentualObjetivo) > 100)
            {
                _handlerBase.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
                return false;
            }

            _distribuicaoRepositorio.Insert(_mapper.Map<DistribuicaoPorAtivo>(request));
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AlterarDistribuicaoPorAtivoCommand request, CancellationToken cancellationToken)
        {
            if (!_handlerBase.ValidateCommand(request))
                return false;
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

        private decimal PercentualObjetivoAcumulado(Guid id, decimal percentualObjetivo)
        {
            decimal percentualAcumulado = _distribuicaoRepositorio.GetManyBy(d => d.Id != id).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo;
        }

        private async Task<bool> Update(DistribuicaoPorAtivo entity)
        {
            _distribuicaoRepositorio.Update(entity);
            return await _distribuicaoRepositorio.UnitOfWork.Commit();
        }
    }
}