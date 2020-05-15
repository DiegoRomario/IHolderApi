using IHolder.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Application.Interfaces.Services.Base
{
    public interface IServiceGetManyBy<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetManyBy(Expression<Func<TEntity, bool>> predicate);
    }
}
