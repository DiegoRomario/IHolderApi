using IHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IHolder.Domain.DomainObjects;

namespace IHolder.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutosPorTipoInvestimento(Guid TipoInvestimentoId);
    }
}
