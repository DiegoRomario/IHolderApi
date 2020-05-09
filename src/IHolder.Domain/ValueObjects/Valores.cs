namespace IHolder.Domain.ValueObjects
{
    public class Valores
    {
        public Valores(decimal percentualObjetivo, decimal valorAtual)
        {
            PercentualObjetivo = percentualObjetivo;
            ValorAtual = valorAtual;
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


        public void AtualizarPercentualAtual (decimal valorInvestidoTotal)
        {
            PercentualAtual = (ValorAtual / valorInvestidoTotal) * 100;
        }

        public void AtualizarPercentualDiferenca()
        {
            PercentualDiferenca = PercentualObjetivo - PercentualAtual;
        }

        public void AtualizarValorDiferenca()
        {
            ValorDiferenca = (ValorAtual / PercentualAtual) * PercentualDiferenca;
        }

        public void OrquestrarAtualizacaoDeValoresEPercentuais(decimal valorTotalPorTipoInvestimento, decimal totalGeral)
        {
            AtualizarValorAtual(valorTotalPorTipoInvestimento);
            AtualizarPercentualAtual(totalGeral);
            AtualizarPercentualDiferenca();
            AtualizarValorDiferenca();
        }


    }
}
