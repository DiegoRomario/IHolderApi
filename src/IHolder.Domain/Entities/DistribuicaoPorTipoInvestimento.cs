using IHolder.Domain.Enumerators;
using IHolder.Domain.Interfaces;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorTipoInvestimento : IDistribuicao
    {
        private DistribuicaoPorTipoInvestimento() { }
        public DistribuicaoPorTipoInvestimento(Guid tipoInvestimentoId, Guid usuarioId, Valores valores) : base(valores)
        {
            TipoInvestimentoId = tipoInvestimentoId;
            Orientacao = EOrientacao.Hold;
            UsuarioId = usuarioId;
        }
        public Guid TipoInvestimentoId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public TipoInvestimento TipoInvestimento { get; private set; }
        protected override EOrientacao SugerirOrientacao()
        {
            if (ExcedePercentualDeDiferenca())
                return EOrientacao.Sell;
            else if (Valores.PercentualDiferenca <= 0)
                return EOrientacao.Hold;
            else
                return EOrientacao.Buy;
        }
    }
}
