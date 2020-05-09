﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IHolder.Domain.DomainObjects
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<bool> Insert(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(Guid id);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetManyBy(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        Task<bool> SaveChanges();

    }
}