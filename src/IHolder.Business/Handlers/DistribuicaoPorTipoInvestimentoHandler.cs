using AutoMapper;
using IHolder.Business.Base;
using IHolder.Business.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Business.Handlers
{
    public class DistribuicaoPorTipoInvestimentoHandler : IRequestHandler<CadastrarDistribuicaoPorTipoInvestimentoCommand, Response>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorTipoInvestimento> _distribuicaoPorTipoInvestimentoRepository;
        //private readonly IAporteRepository _aporteRepository;
        private readonly IResponse _response;

        public DistribuicaoPorTipoInvestimentoHandler(IMapper mapper, IRepositoryBase<DistribuicaoPorTipoInvestimento> distribuicaoPorTipoInvestimentoRepository, IResponse response)
        {
            _mapper = mapper;
            _distribuicaoPorTipoInvestimentoRepository = distribuicaoPorTipoInvestimentoRepository;
            _response = response;
        }

        public async Task<Response> Handle(CadastrarDistribuicaoPorTipoInvestimentoCommand request, CancellationToken cancellationToken)
        {
            await _distribuicaoPorTipoInvestimentoRepository.Insert(_mapper.Map<DistribuicaoPorTipoInvestimento>(request));
            return _response.Success("Distribuição cadastrada com sucesso");
        }
    }
}
