using IHolder.Domain.Entities;
using System;
using Xunit;

namespace IHolder.Tests.Domain.Tests
{
    public class AtivoEmCarteiraTests
    {
        [Fact(DisplayName = "Calculo do Preço Total")]
        [Trait("AtivoEmCarteira", "AtivoEmCarteira Testes")]
        public void AtivoEmCarteira_DadoPrecoMedioEQuantidade_DeveCalcularValorTotal()
        {
            // Arrange
            AtivoEmCarteira ativoEmCarteira = new AtivoEmCarteira(
                ativoId: Guid.NewGuid(),
                precoMedio: 33.45M, quantidade: 825,
                usuarioId: Guid.NewGuid(),
                dataPrimeiroAporte: DateTime.Now);
            // Act
            ativoEmCarteira.CalcularValorAplicado();
            // Assert 
            Assert.Equal(27596.25M, ativoEmCarteira.ValorAplicado, 2);
        }


        [Fact(DisplayName = "Calculo do preço total com valores maiores excedentes")]
        [Trait("AtivoEmCarteira", "AtivoEmCarteira Testes")]
        public void AtivoEmCarteira_DadoPrecoMedioEQuantidadeComValoresExcedentes_DeveRetornarExcecao()
        {
            // Arrange
            // Act
            var exception = Record.Exception(() =>
            {
                AtivoEmCarteira ativoEmCarteira = new AtivoEmCarteira(
                ativoId: Guid.NewGuid(),
                precoMedio: 999999999999999999995M, quantidade: 999999999999999999995M,
                usuarioId: Guid.NewGuid(),
                dataPrimeiroAporte: DateTime.Now);

            });
            // Assert
            Assert.IsType<OverflowException>(exception);

        }
    }
}
