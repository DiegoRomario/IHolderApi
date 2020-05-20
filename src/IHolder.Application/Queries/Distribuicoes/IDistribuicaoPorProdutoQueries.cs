using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Application.Queries
{
    public interface IDistribuicaoPorProdutoQueries
    {
        Task<IEnumerable<DistribuicaoViewModel>> ObterDistribuicaoPorProduto();
    }
}
