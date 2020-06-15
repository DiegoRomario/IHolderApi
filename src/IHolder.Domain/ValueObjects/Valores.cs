﻿namespace IHolder.Domain.ValueObjects
{
    public class Valores
    {
        public Valores(decimal percentualObjetivo)
        {
            PercentualObjetivo = percentualObjetivo;
        }

        public decimal PercentualObjetivo { get; private set; }
        public decimal PercentualAtual { get; private set; }
        public decimal PercentualDiferenca { get; private set; }
        public decimal ValorAtual { get; private set; }
        public decimal ValorDiferenca { get; private set; }

        public void AtualizarPercentualObjetivo(decimal percentualObjetivo)
        {
            PercentualObjetivo = percentualObjetivo;
        }
        public void AtualizarValorAtual(decimal valorAtual)
        {
            ValorAtual = valorAtual;
        }

        private void AtualizarPercentualAtual (decimal valorInvestidoTotal)
        {
            PercentualAtual = valorInvestidoTotal == 0 ? 0 : (ValorAtual / valorInvestidoTotal) * 100;
        }

        private void AtualizarPercentualDiferenca()
        {
            PercentualDiferenca = PercentualObjetivo - PercentualAtual;
        }

        private void AtualizarValorDiferenca(decimal valorInvestidoTotal)
        {
            if (PercentualAtual <= 0)
                ValorDiferenca = valorInvestidoTotal * PercentualObjetivo / 100;
            else
                ValorDiferenca = (ValorAtual / PercentualAtual) * PercentualDiferenca;
            
        }

        public void OrquestrarAtualizacaoDeValoresEPercentuais(decimal valorTotalPorTipo, decimal valorTotalGeral)
        {
            AtualizarValorAtual(valorTotalPorTipo);
            AtualizarPercentualAtual(valorTotalGeral);
            AtualizarPercentualDiferenca();
            AtualizarValorDiferenca(valorTotalGeral);
        }


    }
}
