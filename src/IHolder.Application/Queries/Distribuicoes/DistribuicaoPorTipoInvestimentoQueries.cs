using AutoMapper;
using IHolder.Application.ViewModels;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public class DistribuicaoPorTipoInvestimentoQueries : IDistribuicaoPorTipoInvestimentoQueries
    {
        private readonly IRepositoryBase<DistribuicaoPorTipoInvestimento> _repository;
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<AtivoEmCarteira> _AtivoEmCarteiraRepository;


        public DistribuicaoPorTipoInvestimentoQueries(IRepositoryBase<DistribuicaoPorTipoInvestimento> repository, IMapper mapper, IRepositoryBase<AtivoEmCarteira> AtivoEmCarteiraRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _AtivoEmCarteiraRepository = AtivoEmCarteiraRepository;
        }

        public async Task<IEnumerable<DistribuicaoViewModel>> ObterDistribuicaoPorTipoInvestimento()
        {
            var distribuicoes = _mapper.Map<IEnumerable<DistribuicaoPorTipoInvestimento>, IEnumerable<DistribuicaoViewModel>>
                (await _repository.GetManyBy(includes: a => a.TipoInvestimento));

#warning REFATORAR!
            foreach (var item in distribuicoes)
            {
                item.EstaNaCarteira = _AtivoEmCarteiraRepository.GetBy(where: a => a.Ativo.Produto.TipoInvestimentoId == item.TipoDistribuicaoId, a => a.Ativo, a => a.Ativo.Produto, a=>a.Ativo.Produto.TipoInvestimento).Result != null;
            }

            return distribuicoes.OrderByDescending(a => a.EstaNaCarteira);
        }
    }
}
