using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Application.Queries.Distribuicoes
{
    public interface IDistribuicaoPorProdutoQueries
    {
        Task<IEnumerable<DistribuicaoViewModel>> ObterDistribuicaoPorProduto();
    }
}
