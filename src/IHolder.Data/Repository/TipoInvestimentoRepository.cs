using IHolder.Domain.Entities;

using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IHolder.Domain.Interfaces;
using IHolder.Domain.DomainObjects;

namespace IHolder.Data.Repository
{
    public class TipoInvestimentoRepository : RepositoryBase<TipoInvestimento>, IRepositoryBase<TipoInvestimento>
    {
        public TipoInvestimentoRepository(IHolderContext context) : base(context)
        {
        }

        public  override async Task<IEnumerable<TipoInvestimento>> GetAll()
        {
            return await _dbSet.AsNoTracking().Include(p => p.Produtos).ToListAsync();
        }
    }
}
