﻿using IHolder.Business.Entities;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IHolder.Data.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(IHolderContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Produto>> ObterProdutosPorTipoInvestimento(int Tipo_investimento_id)
        {
            return await GetManyBy(p => p.Tipo_investimento_id == Tipo_investimento_id);
        }
    }
}
