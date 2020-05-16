using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IHolder.Data.Repository
{
    public class DistribuicaoPorTipoInvestimentoRepository : RepositoryBase<DistribuicaoPorTipoInvestimento>, IDistribuicaoPorTipoInvestimentoRepository
    {
        public DistribuicaoPorTipoInvestimentoRepository(IHolderContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DistribuicaoPorTipoInvestimento>> ObterDistribuicaoPorTipoInvestimento
            (params Expression<Func<DistribuicaoPorTipoInvestimento, object>>[] expressions)
        {
            var query = _dbSet.AsNoTracking();
            foreach (var item in expressions)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

    }
}
