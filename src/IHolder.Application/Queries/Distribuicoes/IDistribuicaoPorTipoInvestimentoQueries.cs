using IHolder.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IDistribuicaoPorTipoInvestimentoQueries
    {
        Task<IEnumerable<DistribuicaoViewModel>> ObterDistribuicaoPorTipoInvestimento();
    }
}
