using AutoMapper;
using IHolder.Application.Base;
using IHolder.Application.ViewModels;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public class DistribuicaoPorTipoInvestimentoQueries : IDistribuicaoPorTipoInvestimentoQueries
    {
        private readonly IDistribuicaoPorTipoInvestimentoRepository _distribuicaoPorTipoInvestimentoRepository;
        private readonly IMapper _mapper;
        private readonly IResponse _response;

        public DistribuicaoPorTipoInvestimentoQueries(IDistribuicaoPorTipoInvestimentoRepository distribuicaoPorTipoInvestimentoRepository, IMapper mapper, IResponse response)
        {
            _distribuicaoPorTipoInvestimentoRepository = distribuicaoPorTipoInvestimentoRepository;
            _mapper = mapper;
            _response = response;
        }

        public async Task<Response> ObterDistribuicaoPorTipoInvestimento()
        {
            var distribuicoes = _mapper.Map<IEnumerable<DistribuicaoPorTipoInvestimento>, IEnumerable<DistribuicaoPorTipoInvestimentoViewModel>>
                (await _distribuicaoPorTipoInvestimentoRepository.ObterDistribuicaoPorTipoInvestimento());
            return _response.Success(distribuicoes);
        }
    }
}
