using IHolder.Domain.Entities;
using IHolder.Data.Context;
using IHolder.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IHolder.Domain.Interfaces;

namespace IHolder.Data.Repository
{
    public class AporteRepository : RepositoryBase<Aporte>, IAporteRepository
    {
        public AporteRepository(IHolderContext context) : base(context)
        {
        }

        public async Task<decimal> ObterTotalAplicado(Guid usuarioId)
        {
            decimal total = await(from aporte in _context.Aportes
                                  join ativo in _context.Ativos on aporte.AtivoId equals ativo.Id
                                  join produto in _context.Produtos on ativo.ProdutoId equals produto.Id
                                  where aporte.UsuarioId == usuarioId
                                  group produto.Id by new { aporte.Quantidade, ativo.Cotacao } into resultado
                                  select resultado.Key.Cotacao * resultado.Key.Quantidade)
                                        .SumAsync();
            return total;
        }

        public async Task<decimal> ObterTotalAplicadoPorAtivo(Guid ativoId, Guid usuarioId)
        {
            decimal total = await (from aporte in _context.Aportes
                                   join ativo in _context.Ativos on aporte.AtivoId equals ativo.Id
                                   where ativo.Id == ativoId && aporte.UsuarioId == usuarioId
                                   group ativo.Id by new { aporte.Quantidade, ativo.Cotacao } into resultado
                                   select resultado.Key.Cotacao * resultado.Key.Quantidade)
                                        .SumAsync();
            return total;
        }

        public async Task<decimal> ObterTotalAplicadoPorProduto(Guid produtoId, Guid usuarioId)
        {
            decimal total = await (from ap in _context.Aportes
                                   join at in _context.Ativos on ap.AtivoId equals at.Id
                                   join pr in _context.Produtos on at.ProdutoId equals pr.Id
                                   where pr.Id == produtoId && ap.UsuarioId == usuarioId
                                   group pr.Id by new { ap.Quantidade, at.Cotacao } into atg
                                   select atg.Key.Cotacao * atg.Key.Quantidade)
                                        .SumAsync();
            return total;
        }

        public async Task<decimal> ObterTotalAplicadoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId)
        {
            decimal total = await (from ap in _context.Aportes
                                 join at in _context.Ativos on ap.AtivoId equals at.Id
                                 join pr in _context.Produtos on at.ProdutoId equals pr.Id
                                 where pr.TipoInvestimentoId == tipoInvestimentoId && ap.UsuarioId == usuarioId
                                 group pr.Id by new { ap.Quantidade, at.Cotacao } into atg
                                 select atg.Key.Cotacao * atg.Key.Quantidade)
                                        .SumAsync();
            return total;
        }
    }
}
