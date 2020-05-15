using IHolder.Application.Base;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IDistribuicaoPorTipoInvestimentoQueries
    {
        Task<Response> ObterDistribuicaoPorTipoInvestimento();
    }
}
