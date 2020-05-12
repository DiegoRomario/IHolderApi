using IHolder.Business.Base;
using System.Threading.Tasks;

namespace IHolder.Business.Queries
{
    public interface IDistribuicaoPorTipoInvestimentoQueries
    {
        Task<Response> ObterDistribuicaoPorTipoInvestimento();
    }
}
