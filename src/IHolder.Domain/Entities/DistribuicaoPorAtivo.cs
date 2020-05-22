using IHolder.Domain.DomainObjects;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Entities
{
    public class DistribuicaoPorAtivo : Entity
    {
        private DistribuicaoPorAtivo()
        {
        }
        public DistribuicaoPorAtivo(Guid ativoId, Guid usuarioId, Valores valores)
        {
            AtivoId = ativoId;
            UsuarioId = usuarioId;
            Orientacao = EOrientacao.Hold;
            Valores = valores;
        }
        public  Valores Valores { get; private set; }
        public Guid AtivoId { get; private set; }
        public Guid UsuarioId { get; private set; }
        public EOrientacao Orientacao { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public Ativo Ativo { get; private set; }
        public Usuario Usuario { get; private set; }

        public void AlterarAtivo (Ativo ativo)
        {
            Ativo = ativo;
            AtivoId = ativo.Id;
        }

        public void AtualizarOrientacao(decimal valorTotalPorAtivo, decimal totalGeral)
        {
            Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorAtivo, totalGeral);

#warning IMPLEMENTAR REGRA BASEADO EM X PERIODO DE QUARENTENA
            if (Valores.PercentualDiferenca > 0 && Ativo.Situacao != ESituacao.Quarentena)
                Orientacao = EOrientacao.Buy;
            else if (Valores.PercentualDiferenca <= 0 && Ativo.Situacao != ESituacao.Quarentena)
                Orientacao = EOrientacao.Hold;
            else 
                Orientacao = EOrientacao.Sell;

        }

    }
}
