﻿using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Domain.Interfaces
{
    public abstract class IDistribuicao : Entity
    {
        private const decimal PERCENTUAL_DIFERENCA_EXCEDENTE_ACEITAVEL = 50;
        protected IDistribuicao() { }
        protected IDistribuicao(Valores valores)
        {
            Valores = valores;
            Orientacao = EOrientacao.Hold;
        }
        public Valores Valores { get; private set; }
        public EOrientacao Orientacao { get; protected set; }
        public Usuario Usuario { get; private set; }
        public DateTime DataInclusao { get; private set; }
        public DateTime? DataAlteracao { get; private set; }
        public void AtualizarOrientacao(decimal valorInvestido, decimal ValorTotalInvestido)
        {
            Valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorInvestido, ValorTotalInvestido);
            Orientacao = SugerirOrientacao();
        }
        protected abstract EOrientacao SugerirOrientacao();

        protected bool ExcedePercentualDeDiferenca()
        {
            return Valores.PercentualAtual >
            Valores.PercentualObjetivo +
            (Valores.PercentualObjetivo * PERCENTUAL_DIFERENCA_EXCEDENTE_ACEITAVEL / 100);
        }
    }
}
