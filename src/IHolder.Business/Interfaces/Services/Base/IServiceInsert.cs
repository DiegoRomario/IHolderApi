using IHolder.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Services.Base
{
    public interface IServiceInsert <TEntity> where TEntity : Entidade_base
    {
        Task<bool> Insert(TEntity entity);
    }
}
