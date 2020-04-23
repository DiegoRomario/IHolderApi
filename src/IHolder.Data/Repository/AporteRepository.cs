using IHolder.Business.Entities;
using IHolder.Business.Interfaces.Repositories;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHolder.Data.Repository
{
    public class AporteRepository : RepositoryBase<Aporte>, IAporteRepository
    {
        public AporteRepository(IHolderContext context) : base(context)
        {
        }

        public async Task<decimal> ObterTotalAplicado(Guid usuario_id)
        {
            decimal total = await(from ap in _context.Aportes
                                  join at in _context.Ativos on ap.Ativo_id equals at.Id
                                  join pr in _context.Produtos on at.Produto_id equals pr.Id
                                  where ap.Usuario_id == usuario_id
                                  group pr.Id by new { ap.Quantidade, at.Cotacao } into atg
                                  select atg.Key.Cotacao * atg.Key.Quantidade)
                                        .SumAsync();
            return total;
        }

        public async Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipo_investimento_id, Guid usuario_id)
        {
            decimal total = await (from ap in _context.Aportes
                                 join at in _context.Ativos on ap.Ativo_id equals at.Id
                                 join pr in _context.Produtos on at.Produto_id equals pr.Id
                                 where pr.Tipo_investimento_id == tipo_investimento_id && ap.Usuario_id == usuario_id
                                 group pr.Id by new { ap.Quantidade, at.Cotacao } into atg
                                 select atg.Key.Cotacao * atg.Key.Quantidade)
                                        .SumAsync();
            return total;
        }
    }
}
