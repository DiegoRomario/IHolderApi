using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public class ProdutoQueries : IProdutoQueries
    {
        private readonly IRepositoryBase<Produto> _repository;
        private readonly IMapper _mapper;

        public ProdutoQueries(IRepositoryBase<Produto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterProdutos()
        {
            IEnumerable<Produto> produtos = await _repository.GetManyBy();
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);
        }
    }
}
