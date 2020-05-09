using IHolder.Business.Interfaces.Services.Base;
using IHolder.Domain.Entities;

namespace IHolder.Business.Interfaces.Services
{
    public interface IUsuarioService : IServiceGetBy<Usuario>, 
                                       IServiceInsert<Usuario>,
                                       IServiceUpdate<Usuario>
    {
    }
}
