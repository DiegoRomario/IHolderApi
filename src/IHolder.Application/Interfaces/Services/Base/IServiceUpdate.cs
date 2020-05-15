using IHolder.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Application.Interfaces.Services.Base
{
    public interface IServiceUpdate<TEntity> where TEntity : Entity
    {
        Task<bool> Update(TEntity entity);
    }
}
