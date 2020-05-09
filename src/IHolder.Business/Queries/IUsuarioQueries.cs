using IHolder.Business.ViewModels;
using System.Threading.Tasks;

namespace IHolder.Business.Queries
{
    public interface IUsuarioQueries
    {
        Task<UsuarioAutenticadoViewModel> AutenticarUsuario(UsuarioLoginArgs login);
    }
}
