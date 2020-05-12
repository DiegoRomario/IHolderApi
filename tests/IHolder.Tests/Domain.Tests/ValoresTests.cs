using IHolder.Domain.ValueObjects;
using Xunit;

namespace IHolder.Tests.Domain.Tests
{

    public class ValoresTests
    {
        Valores valores = new Valores(10);

        public ValoresTests()
        {
            valores.AtualizarValorAtual(6500);
            valores.AtualizarPercentualAtual(100000);
            valores.AtualizarPercentualDiferenca();
        }

        [Fact(DisplayName = "Calculo do % Atual")]
        [Trait("Valores Base", "Valores Base Trait Testes")]
        public void valores_DadoValorTotalInvestidoEValorAtualDoAtivo_DeveCalcularPercentualAtual()
        {
            // Arrange
            // Act
            valores.AtualizarPercentualAtual(100000);

            // Assert 
            Assert.Equal(6.5M, valores.PercentualAtual, 2);
        }

        [Fact(DisplayName = "Calculo do % Diferença")]
        [Trait("Valores Base", "Valores Base Trait Testes")]
        public void valores_DadoPercentualObjetivoEPercentualAtual_DeveCalcularPercentualDiferenca()
        {
            // Arrange
            // Act
            valores.AtualizarPercentualDiferenca();

            // Assert 
            Assert.Equal(3.5M, valores.PercentualDiferenca, 2);
        }

        [Fact(DisplayName = "Calculo do Valor Diferença")]
        [Trait("Valores Base", "Valores Base Trait Testes")]
        public void valores_DadoValorAtualEPercentualAtualEPercentualDiferenca_DeveCalcularValorDiferenca()
        {
            // Arrange
            // Act
            valores.AtualizarValorDiferenca();

            // Assert 
            Assert.Equal(3500M, valores.ValorDiferenca, 2);
        }

    }

}
