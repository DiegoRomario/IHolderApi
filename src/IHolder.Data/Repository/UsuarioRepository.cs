using IHolder.Domain.Entities;
using IHolder.Business.Repositories.Base;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IRepositoryBase<Usuario>
    {
        public UsuarioRepository(IHolderContext context) : base(context)
        {
        }
    }
}
