using AutoMapper;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries.Distribuicoes
{
    public class DistribuicaoPorProdutoQueries : IDistribuicaoPorProdutoQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorProduto> _repository;

        public DistribuicaoPorProdutoQueries(IMapper mapper, IRepositoryBase<DistribuicaoPorProduto> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<DistribuicaoPorProdutoViewModel>> ObterDistribuicaoPorProduto()
        {
            var distribuicoes = _mapper.Map<IEnumerable<DistribuicaoPorProdutoViewModel>>(await _repository.GetManyBy(includes: d => d.Produto));
            return distribuicoes;
        }
    }
}
