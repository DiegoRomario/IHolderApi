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

        public DistribuicaoPorTipoInvestimentoQueries(IDistribuicaoPorTipoInvestimentoRepository distribuicaoPorTipoInvestimentoRepository, IMapper mapper)
        {
            _distribuicaoPorTipoInvestimentoRepository = distribuicaoPorTipoInvestimentoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DistribuicaoPorTipoInvestimentoViewModel>> ObterDistribuicaoPorTipoInvestimento()
        {
            var distribuicoes = _mapper.Map<IEnumerable<DistribuicaoPorTipoInvestimento>, IEnumerable<DistribuicaoPorTipoInvestimentoViewModel>>
                (await _distribuicaoPorTipoInvestimentoRepository.ObterDistribuicaoPorTipoInvestimento());
            return distribuicoes;
        }
    }
}
