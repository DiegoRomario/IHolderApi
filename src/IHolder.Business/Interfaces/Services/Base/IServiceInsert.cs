using IHolder.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services.Base
{
    public interface IServiceInsert <TEntity> where TEntity : Entity
    {
        Task<bool> Insert(TEntity entity);
    }
}
