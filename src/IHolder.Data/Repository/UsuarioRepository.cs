using IHolder.Domain.Entities;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using IHolder.Domain.DomainObjects;

namespace IHolder.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IRepositoryBase<Usuario>
    {
        public UsuarioRepository(IHolderContext context) : base(context)
        {
        }
    }
}
