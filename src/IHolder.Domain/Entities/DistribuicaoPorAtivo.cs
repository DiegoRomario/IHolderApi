using IHolder.Domain.Enumerators;
using IHolder.Domain.Interfaces;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorAtivo : IDistribuicao
    {
        private const int MAXIMO_DIAS_EM_QUARENTENA = 180;
        private DistribuicaoPorAtivo() { }
        public DistribuicaoPorAtivo(Guid ativoId, Guid usuarioId, Valores valores) : base(valores)
        {
            AtivoId = ativoId;
            UsuarioId = usuarioId;
        }
        public Guid AtivoId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Ativo Ativo { get; private set; }
        public void AlterarAtivo(Ativo ativo)
        {
            Ativo = ativo;
            AtivoId = ativo.Id;
        }
        protected override EOrientacao SugerirOrientacao()
        {
            if ((ExcedeuDiasEmQuarentena() && Ativo.Situacao == ESituacao.Quarentena) || ExcedePercentualDeDiferenca())
                return EOrientacao.Sell;
            else if (Valores.PercentualDiferenca > 0 && Ativo.Situacao != ESituacao.Quarentena)
                return EOrientacao.Buy;
            else if (Valores.PercentualDiferenca <= 0 && Ativo.Situacao != ESituacao.Quarentena)
                return EOrientacao.Hold;
            else
                return EOrientacao.Hold;
        }
        private bool ExcedeuDiasEmQuarentena()
        {
            return Ativo.DataReferenciaSituacao.AddDays(MAXIMO_DIAS_EM_QUARENTENA) < DateTime.Now;
        }

    }
}
