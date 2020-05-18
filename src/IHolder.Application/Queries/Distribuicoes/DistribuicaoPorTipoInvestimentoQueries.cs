using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public class DistribuicaoPorTipoInvestimentoQueries : IDistribuicaoPorTipoInvestimentoQueries
    {
        private readonly IRepositoryBase<DistribuicaoPorTipoInvestimento> _repository;
        private readonly IMapper _mapper;

        public DistribuicaoPorTipoInvestimentoQueries(IRepositoryBase<DistribuicaoPorTipoInvestimento> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DistribuicaoPorTipoInvestimentoViewModel>> ObterDistribuicaoPorTipoInvestimento()
        {
            var distribuicoes = _mapper.Map<IEnumerable<DistribuicaoPorTipoInvestimento>, IEnumerable<DistribuicaoPorTipoInvestimentoViewModel>>
                (await _repository.GetManyBy(includes: a => a.TipoInvestimento));
            return distribuicoes;
        }
    }
}
