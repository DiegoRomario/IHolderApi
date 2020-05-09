using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System.Collections.Generic;

namespace IHolder.Domain.Entities
{
    public class TipoInvestimento : Entity
    {

        private TipoInvestimento()
        {

        }
        public TipoInvestimento(ERisco risco, Informacoes informacoes)
        {
            Risco = risco;
            Informacoes = informacoes;
        }
        public Informacoes Informacoes { get; set; }
        public ERisco Risco { get; private set; }
        public IEnumerable<DistribuicaoPorTipoInvestimento> DistribuicoesPorTiposInvestimentos { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }

        public void AlterarRisco(ERisco risco)
        {
            Risco = risco;
        }

    }
}
