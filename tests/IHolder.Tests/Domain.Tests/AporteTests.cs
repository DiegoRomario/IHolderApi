using IHolder.Domain.Entities;
using System;
using Xunit;

namespace IHolder.Tests.Domain.Tests
{
    public class AporteTests
    {
        [Fact(DisplayName = "Calculo do Preço Total")]
        [Trait("Aporte", "Aporte Testes")]
        public void Aporte_DadoPrecoMedioEQuantidade_DeveCalcularValorTotal()
        {
            // Arrange
            Aporte aporte = new Aporte(
                ativoId: Guid.NewGuid(),
                precoMedio: 33.45M, quantidade: 825,
                usuarioId: Guid.NewGuid(),
                dataAporte: DateTime.Now);
            // Act
            aporte.CalcularPrecoTotal();
            // Assert 
            Assert.Equal(27596.25M, aporte.PrecoTotal, 2);
        }


        [Fact(DisplayName = "Calculo do preço total com valores maiores excedentes")]
        [Trait("Aporte", "Aporte Testes")]
        public void Aporte_DadoPrecoMedioEQuantidadeComValoresExcedentes_DeveRetornarExcecao()
        {
            // Arrange
            // Act
            var exception = Record.Exception(() =>
            {
                Aporte aporte = new Aporte(
                ativoId: Guid.NewGuid(),
                precoMedio: 999999999999999999995M, quantidade: 999999999999999999995M,
                usuarioId: Guid.NewGuid(),
                dataAporte: DateTime.Now);

            });
            // Assert
            Assert.IsType<OverflowException>(exception);

        }
    }
}
