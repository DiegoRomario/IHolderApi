using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorTipoInvestimento : Entity
    {

        private DistribuicaoPorTipoInvestimento()
        {

        }
        public DistribuicaoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId, Valores valores)
        {
            TipoInvestimentoId = tipoInvestimentoId;
            Orientacao = EOrientacao.Hold;
            UsuarioId = usuarioId;
            Valores = valores;
        }

        public Valores Valores { get; private set; }
        public Guid TipoInvestimentoId { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public Guid UsuarioId { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }

        // EF RELATIONS
        public TipoInvestimento TipoInvestimento { get; private set; }

        public Usuario Usuario { get; private set; }
        public void AtualizarOrientacao()
        {
            if (Valores.PercentualDiferenca <= 0)
                Orientacao = EOrientacao.Hold;
            else
                Orientacao = EOrientacao.Buy;
        }

    }
}
