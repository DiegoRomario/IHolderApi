using IHolder.Application.Base;
using IHolder.Application.ViewModels;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IUsuarioQueries
    {
       Task<Response> AutenticarUsuario(UsuarioLoginArgs login);
    }
}
