
using IHolder.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IHolder.Domain.DomainObjects;

namespace IHolder.Data.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        protected readonly IHolderContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public IUnitOfWork UnitOfWork => _context;

        public RepositoryBase(IHolderContext context)
        {
            this._context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(Guid id)
        {
            _dbSet.Remove(_dbSet.Single(d => d.Id == id));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetManyBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {

            var query = _dbSet.AsNoTracking();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            if (where != null)
                query = query.Where(where);

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbSet.AsNoTracking();

            foreach (var item in includes)
            {
                query = query.Include(item);
            }

            if (where != null)
                query = query.Where(where);

            return await query.FirstOrDefaultAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
