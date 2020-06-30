using IHolder.Domain.ValueObjects;
using Xunit;


namespace IHolder.Tests.Domain.Tests
{
    public class ValoresTests
    {
        Valores valores;
        public ValoresTests()
        {
            valores = new Valores(percentualObjetivo: 25);
        }

        [Fact(DisplayName = "Calculo % Atual")]
        [Trait("Categoria", "Valores")]
        public void DadoPercentualObjetivoValorAtualPorAtivoEValorTotalInvestido_DeveCalcularPercentuaisValoresEDiferencasAtuais()
        {
            // Arrange            
            // Act
            valores.OrquestrarAtualizacaoDeValoresEPercentuais(valorInvestido: 2000, ValorTotalInvestido: 10000);
            // Assert
            Assert.Equal(20, valores.PercentualAtual);
            Assert.Equal(5, valores.PercentualDiferenca);
            Assert.Equal(500, valores.ValorDiferenca);
        }

        [Fact(DisplayName = "Arredondamento % Objetivo")]
        [Trait("Categoria", "Valores")]
        public void DadoPercentualObjetivoComXCasasDecimais_DeveAtualizarArredondandoParaBaixoComDuasCasasDecimais()
        {
            // Arrange
            // Act
            valores.AtualizarPercentualObjetivo(14.65688m);
            // Assert
            Assert.Equal(14.65m, valores.PercentualObjetivo);

        }

    }

}
