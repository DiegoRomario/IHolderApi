using AutoMapper;
using IHolder.Business.Base;
using IHolder.Business.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Business.Handlers
{
    public class DistribuicaoPorTipoInvestimentoHandler : 
        IRequestHandler<CadastrarDistribuicaoPorTipoInvestimentoCommand, Response>,
        IRequestHandler<AlterarDistribuicaoPorTipoInvestimentoCommand, Response>,
        IRequestHandler<RecalcularDistribuicaoPorTipoInvestimentoCommand, Response>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorTipoInvestimento> _distribuicaoPorTipoInvestimentoRepository;
        private readonly IAporteRepository _aporteRepository;
        private readonly IResponse _response;

        public DistribuicaoPorTipoInvestimentoHandler(IMapper mapper, IRepositoryBase<DistribuicaoPorTipoInvestimento> distribuicaoPorTipoInvestimentoRepository, IResponse response, IAporteRepository aporteRepository)
        {
            _mapper = mapper;
            _distribuicaoPorTipoInvestimentoRepository = distribuicaoPorTipoInvestimentoRepository;
            _response = response;
            _aporteRepository = aporteRepository;
        }

        public async Task<Response> Handle(CadastrarDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            if (PercentualObjetivoAcumulado(request.TipoInvestimentoId, request.PercentualObjetivo) > 100)
                return _response.Error("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");

            await _distribuicaoPorTipoInvestimentoRepository.Insert(_mapper.Map<DistribuicaoPorTipoInvestimento>(request));
            return _response.Success("Distribuição cadastrada com sucesso");
        }

        public async Task<Response> Handle(AlterarDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            await Update(_mapper.Map<DistribuicaoPorTipoInvestimento>(request));
            return _response.Success("Distribuição alteradas com sucesso");
        }

        public async Task<Response> Handle(RecalcularDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            List<DistribuicaoPorTipoInvestimento> distribuicoes = _distribuicaoPorTipoInvestimentoRepository.GetManyBy(d => d.UsuarioId == request.UsuarioId).Result.ToList();
            var valor_total = _aporteRepository.ObterTotalAplicado(request.UsuarioId).Result;

            foreach (var item in distribuicoes)
            {
                var valorTotalPorTipoInvestimento = _aporteRepository.ObterTotalAplicadoPorTipoInvestimento(item.TipoInvestimentoId, request.UsuarioId).Result;
                item.Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorTipoInvestimento, valor_total);
                item.AtualizarOrientacao();
                await Update(item);
            }

            return _response.Success("Distribuições atualizadas com sucesso");
        }

        private decimal PercentualObjetivoAcumulado(Guid id, decimal percentualObjetivo)
        {
            decimal percentualAcumulado = _distribuicaoPorTipoInvestimentoRepository.GetManyBy(d => d.Id != id).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo;
        }

        private async Task<bool> Update(DistribuicaoPorTipoInvestimento entity)
        {
            return await _distribuicaoPorTipoInvestimentoRepository.Update(entity);
        }

    }
}
