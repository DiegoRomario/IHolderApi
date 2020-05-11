using IHolder.Business.Base;
using IHolder.Business.ViewModels;
using System.Threading.Tasks;

namespace IHolder.Business.Queries
{
    public interface IUsuarioQueries
    {
       Task<Response> AutenticarUsuario(UsuarioLoginArgs login);
    }
}
