using IHolder.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services.Base
{
    public interface IServiceGetAll<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
    }
}
