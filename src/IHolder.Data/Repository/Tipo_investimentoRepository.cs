using IHolder.Domain.Entities;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Data.Repository
{
    public class Tipo_investimentoRepository : RepositoryBase<TipoInvestimento>, ITipoInvestimentoRepository
    {
        public Tipo_investimentoRepository(IHolderContext context) : base(context)
        {
        }

        public  override async Task<IEnumerable<TipoInvestimento>> GetAll()
        {
            return await _dbSet.AsNoTracking().Include(p => p.Produtos).ToListAsync();
        }
    }
}
