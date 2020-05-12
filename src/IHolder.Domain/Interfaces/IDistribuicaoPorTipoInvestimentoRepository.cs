using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Domain.Interfaces
{
    public interface IDistribuicaoPorTipoInvestimentoRepository : IRepositoryBase<DistribuicaoPorTipoInvestimento>
    {
        Task<IEnumerable<DistribuicaoPorTipoInvestimento>> ObterDistribuicaoPorTipoInvestimento();
    }
}
