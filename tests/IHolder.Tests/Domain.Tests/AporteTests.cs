using IHolder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IHolder.Tests.Domain.Tests
{
    public class AporteTests
    {
        [Fact(DisplayName = "Calculo do Preço Total")]
        [Trait("Aporte", "Aporte Trait Testes")]
        public void Aporte_DadoPrecoMedioEQuantidade_DeveCalcularValorTotal()
        {
            // Arrange
            Aporte aporte = new Aporte(Guid.NewGuid(), 33.45M, 825, Guid.NewGuid(), DateTime.Now);
            // Act
            aporte.CalcularPrecoTotal();
            // Assert 
            Assert.Equal(27596.25M, aporte.PrecoTotal, 2);
        }
    }
}
