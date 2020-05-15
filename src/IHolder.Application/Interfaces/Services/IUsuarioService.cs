using IHolder.Application.Interfaces.Services.Base;
using IHolder.Domain.Entities;

namespace IHolder.Application.Interfaces.Services
{
    public interface IUsuarioService : IServiceGetBy<Usuario>, 
                                       IServiceInsert<Usuario>,
                                       IServiceUpdate<Usuario>
    {
    }
}
