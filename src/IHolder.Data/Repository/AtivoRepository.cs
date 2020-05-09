using IHolder.Domain.Entities;

using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using IHolder.Domain.Interfaces;

namespace IHolder.Data.Repository
{
    public class AtivoRepository : RepositoryBase<Ativo>, IAtivoRepository
    {
        public AtivoRepository(IHolderContext context) : base(context)
        {
        }
    }
}
