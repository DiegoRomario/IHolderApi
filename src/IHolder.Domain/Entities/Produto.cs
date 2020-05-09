using IHolder.Domain.DomainObjects;
using IHolder.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IHolder.Domain.Entities
{
    public class Produto : Entity
    {
        private Produto()
        {
        }
        public Produto(Guid tipoInvestimentoId, Informacoes informacoes) 
        {
            TipoInvestimentoId = tipoInvestimentoId;

            Informacoes = informacoes;
        }

        public Informacoes Informacoes { get; set; }
        public Guid TipoInvestimentoId { get; private set; }

        public TipoInvestimento TipoInvestimento { get; private set; }
        public IEnumerable<DistribuicaoPorProduto> DistribuicoesPorProdutos { get; private set; }
        public IEnumerable<Ativo> Ativos { get; private set; }
    }
}
