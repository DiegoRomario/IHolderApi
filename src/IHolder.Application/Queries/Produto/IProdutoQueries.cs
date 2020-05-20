using IHolder.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IProdutoQueries
    {
        Task<IEnumerable<ProdutoViewModel>> ObterProdutos();
    }
}
