using IHolder.Domain.DomainObjects;
using IHolder.Domain.ValueObjects;
using System.Collections.Generic;

namespace IHolder.Domain.Entities
{
    public class TipoInvestimento : Entity
    {

        private TipoInvestimento()
        {

        }
        public TipoInvestimento(Informacoes informacoes)
        {
            Informacoes = informacoes;
        }
        public Informacoes Informacoes { get; set; }
        public IEnumerable<DistribuicaoPorTipoInvestimento> DistribuicoesPorTiposInvestimentos { get; private set; }
        public IEnumerable<Produto> Produtos { get; private set; }

    }
}
