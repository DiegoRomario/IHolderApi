using IHolder.Domain.ValueObjects;
using Xunit;


namespace IHolder.Tests.Domain.Tests
{

    public class ValoresTests
    {

        //[Fact(DisplayName = "Calculo do % Atual")]
        //[Trait("Valores Base", "Valores Base Trait Testes")]
        //public void Valores_DadoValorAtualDoAtivoEValorTotalInvestido_DeveCalcularPercentualAtual()
        //{
        //    // Arrange
        //    valores.AtualizarValorAtual(6500);
        //    // Act
        //    valores.AtualizarPercentualAtual(100000);
        //    // Assert 
        //    Assert.Equal(6.5M, valores.PercentualAtual, 2);
        //}

        //[Fact(DisplayName = "Calculo do % Diferença")]
        //[Trait("Valores Base", "Valores Base Trait Testes")]
        //public void Valores_DadoPercentualObjetivoEPercentualAtual_DeveCalcularPercentualDiferenca()
        //{
        //    // Arrange
        //    valores.AtualizarValorAtual(6500);
        //    valores.AtualizarPercentualAtual(100000);
        //    // Act
        //    valores.AtualizarPercentualDiferenca();
        //    // Assert 
        //    Assert.Equal(3.5M, valores.PercentualDiferenca, 2);
        //}

        [Theory(DisplayName = "Calculo % Atual, diferença e R$ diferença ")]
        [Trait("Valores Base", "Valores Base Trait Testes")]
        [InlineData(10, 6500, 100000, 6.5, 3.5, 3500)]
        [InlineData(20, 10000, 100000, 10, 10, 10000)]

        public void Valores_DadoValorAtualEValorGeral_DeveCalcularValorDiferenca
            (decimal percentualObjectivo,
            decimal valorTotalPorTipo,
            decimal ValorAplicado,
            decimal percentualAtual,
            decimal percentualDiferenca,
            decimal valorDiferenca)
        {
            // Arrange
            Valores valores = new Valores(percentualObjectivo);
            // Act
            valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorTotalPorTipo, ValorAplicado);

            // Assert 
            Assert.Equal(percentualAtual, valores.PercentualAtual, 2);
            Assert.Equal(percentualDiferenca, valores.PercentualDiferenca, 2);
            Assert.Equal(valorDiferenca, valores.ValorDiferenca, 2);
        }

    }

}
