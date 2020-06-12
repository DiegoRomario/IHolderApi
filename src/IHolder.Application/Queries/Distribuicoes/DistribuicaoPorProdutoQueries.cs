using AutoMapper;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace IHolder.Application.Queries
{
    public class DistribuicaoPorProdutoQueries : IDistribuicaoPorProdutoQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorProduto> _repository;
        private readonly IRepositoryBase<AtivoEmCarteira> _AtivoEmCarteiraRepository;


        public DistribuicaoPorProdutoQueries(IMapper mapper, IRepositoryBase<DistribuicaoPorProduto> repository, IRepositoryBase<AtivoEmCarteira> AtivoEmCarteiraRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _AtivoEmCarteiraRepository = AtivoEmCarteiraRepository;
        }

        public async Task<IEnumerable<DistribuicaoViewModel>> ObterDistribuicaoPorProduto()
        {
            var distribuicoes = _mapper.Map<IEnumerable<DistribuicaoViewModel>>(await _repository.GetManyBy(includes: d => d.Produto));
#warning REFATORAR!
            foreach (var item in distribuicoes)
            {
                item.EstaNaCarteira = _AtivoEmCarteiraRepository.GetBy(where: a => a.Ativo.ProdutoId == item.TipoDistribuicaoId, a => a.Ativo).Result != null;
            }
            return distribuicoes;
        }
    }
}
