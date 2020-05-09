using IHolder.Domain.Entities;

using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using IHolder.Domain.Interfaces;

namespace IHolder.Data.Repository
{
    public class DistribuicaoPorTipoInvestimentoRepository : RepositoryBase<DistribuicaoPorTipoInvestimento>, IDistribuicaoPorTipoInvestimentoRepository
    {
        public DistribuicaoPorTipoInvestimentoRepository(IHolderContext context) : base(context)
        {
        }
    }
}
