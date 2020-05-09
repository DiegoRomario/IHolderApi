using IHolder.Domain.Entities;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IHolder.Domain.Interfaces;

namespace IHolder.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IHolderContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Produto>> ObterProdutosPorTipoInvestimento(Guid TipoInvestimentoId)
        {
            return await GetManyBy(p => p.TipoInvestimentoId == TipoInvestimentoId);
        }
    }
}
