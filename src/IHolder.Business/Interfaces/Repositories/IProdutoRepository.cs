using IHolder.Domain.Entities;
using IHolder.Business.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Business.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorTipoInvestimento(Guid TipoInvestimentoId);
    }
}
