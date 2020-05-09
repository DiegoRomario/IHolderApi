using IHolder.Business.Repositories.Base;
using IHolder.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IHolder.Domain.DomainObjects;

namespace IHolder.Data.Repository.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly IHolderContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(IHolderContext context)
        {
            this._context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetManyBy(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual async Task<bool> Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            return await SaveChanges();
        }
        public virtual async Task<bool> Update(TEntity entity)
        {
            _dbSet.Update(entity);
            return await SaveChanges();
        }
        public virtual async Task <bool> Delete(Guid id)
        {
            string entityName = typeof(TEntity).Name;
            int response = await _context.Database.ExecuteSqlRawAsync($"DELETE {entityName} WHERE ID = {0} ", new object[] {id});
            return response > 1;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.Commit();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }
    }
}
