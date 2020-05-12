using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Data.Repository
{
    public class DistribuicaoPorTipoInvestimentoRepository : RepositoryBase<DistribuicaoPorTipoInvestimento>, IDistribuicaoPorTipoInvestimentoRepository
    {
        public DistribuicaoPorTipoInvestimentoRepository(IHolderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DistribuicaoPorTipoInvestimento>> ObterDistribuicaoPorTipoInvestimento()
        {
            return await _dbSet.AsNoTracking().Include(d => d.TipoInvestimento).ToListAsync();
        }
    }
}
