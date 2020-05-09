using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorTipoInvestimento : Entity
    {
        public DistribuicaoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId, Valores valores)
        {
            TipoInvestimentoId = tipoInvestimentoId;
            Orientacao = EOrientacao.Manter;
            UsuarioId = usuarioId;
            Valores = valores;
        }

        public Valores Valores { get; private set; }
        public Guid TipoInvestimentoId { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public Guid UsuarioId { get; private set; }
        public DateTime IncluidoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        // EF RELATIONS
        public TipoInvestimento TipoInvestimento { get; private set; }

        public Usuario Usuario { get; private set; }
        public IEnumerable<DistribuicaoPorProduto> DistribuicoesPorProdutos { get; private set; }

        public void AtualizarOrientacao()
        {
            if (Valores.PercentualDiferenca <= 0)
                Orientacao = EOrientacao.Manter;
            else
                Orientacao = EOrientacao.Comprar;
        }

    }
}
