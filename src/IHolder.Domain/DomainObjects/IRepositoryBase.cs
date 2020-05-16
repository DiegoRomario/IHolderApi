using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IHolder.Domain.DomainObjects
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetManyBy(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includes);
        //Task<IEnumerable<TEntity>> GetManyBy(Expression<Func<TEntity, bool>> where);
        //Task<TEntity> GetBy(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> where = null, params Expression<Func<TEntity, object>>[] includes);

        IUnitOfWork UnitOfWork { get; }

    }
}
