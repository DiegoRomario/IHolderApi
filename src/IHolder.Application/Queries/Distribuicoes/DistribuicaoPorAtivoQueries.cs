using AutoMapper;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries.Distribuicoes
{
    public class DistribuicaoPorAtivoQueries : IDistribuicaoPorAtivoQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorAtivo> _repository;

        public DistribuicaoPorAtivoQueries(IMapper mapper, IRepositoryBase<DistribuicaoPorAtivo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<DistribuicaoPorAtivoViewModel>> ObterDistribuicaoPorAtivo()
        {
            var distribuicoes = _mapper.Map<IEnumerable<DistribuicaoPorAtivoViewModel>>(await _repository.GetManyBy(includes: d => d.Ativo));
            return distribuicoes;
        }
    }
}
