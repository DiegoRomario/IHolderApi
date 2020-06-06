using AutoMapper;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public class DistribuicaoPorAtivoQueries : IDistribuicaoPorAtivoQueries
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<DistribuicaoPorAtivo> _AtivoRepository;
        private readonly IRepositoryBase<Aporte> _aporteRepository;

        public DistribuicaoPorAtivoQueries(IMapper mapper, IRepositoryBase<DistribuicaoPorAtivo> repository, IRepositoryBase<Aporte> aporteRepository)
        {
            _mapper = mapper;
            _AtivoRepository = repository;
            _aporteRepository = aporteRepository;
        }

        public async Task<IEnumerable<DistribuicaoViewModel>> ObterDistribuicaoPorAtivo()
        {
            List<DistribuicaoViewModel> distribuicoes = _mapper.Map<IEnumerable<DistribuicaoViewModel>>(await _AtivoRepository.GetManyBy(includes: d => d.Ativo)).ToList();
#warning REFATORAR!
            foreach (var item in distribuicoes)
            {
                item.EstaNaCarteira = _aporteRepository.GetBy(where: a => a.AtivoId == item.TipoDistribuicaoId).Result != null;
            }
            return distribuicoes;
        }
    }
}
