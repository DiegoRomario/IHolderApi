using IHolder.Domain.DomainObjects;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services.Base
{
#warning renaming 
    public interface IServiceGetBy<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
    }
}


