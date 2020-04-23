using IHolder.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services.Base
{
    public interface IServiceGetManyBy<TEntity> where TEntity : Entidade_base
    {
        Task<IEnumerable<TEntity>> GetManyBy(Expression<Func<TEntity, bool>> predicate);
    }
}
