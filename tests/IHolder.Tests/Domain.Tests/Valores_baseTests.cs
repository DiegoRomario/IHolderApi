using IHolder.Business.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IHolder.Tests.Domain.Tests
{

    public class Valores_baseTests
    {
        Valores_base_tests valores_base = new Valores_base_tests(10, 6500);

        public Valores_baseTests()
        {
            valores_base.AtualizarValorAtual(6500);
            valores_base.AtualizarPercentualAtual(100000);
            valores_base.AtualizarPercentualDiferenca();
        }

        [Fact(DisplayName = "Calculo do % Atual")]
        [Trait("Valores Base", "Valores Base Trait Testes")]
        public void ValoresBase_DadoValorTotalInvestidoEValorAtualDoAtivo_DeveCalcularPercentualAtual()
        {
            // Arrange
            // Act
            valores_base.AtualizarPercentualAtual(100000);

            // Assert 
            Assert.Equal(6.5M, valores_base.Percentual_atual, 2);
        }

        [Fact(DisplayName = "Calculo do % Diferença")]
        [Trait("Valores Base", "Valores Base Trait Testes")]
        public void ValoresBase_DadoPercentualObjetivoEPercentualAtual_DeveCalcularPercentualDiferenca()
        {
            // Arrange
            // Act
            valores_base.AtualizarPercentualDiferenca();

            // Assert 
            Assert.Equal(3.5M, valores_base.Percentual_diferenca, 2);
        }

        [Fact(DisplayName = "Calculo do Valor Diferença")]
        [Trait("Valores Base", "Valores Base Trait Testes")]
        public void ValoresBase_DadoValorAtualEPercentualAtualEPercentualDiferenca_DeveCalcularValorDiferenca()
        {
            // Arrange
            // Act
            valores_base.AtualizarValorDiferenca();

            // Assert 
            Assert.Equal(3500M, valores_base.Valor_diferenca, 2);
        }

    }

    public class Valores_base_tests : Valores_base
    {
        public Valores_base_tests(decimal percentual_objetivo, decimal valor_atual) : base(percentual_objetivo, valor_atual)
        {
        }
    }

}
