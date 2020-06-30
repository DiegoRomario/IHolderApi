using IHolder.Domain.Entities;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IHolder.Tests.Domain.Tests
{
    public class DistribuicoesTests
    { 
        public DistribuicoesTests()
        {

        }

        [Fact(DisplayName = "Atualização de Orientação Por Ativo")]
        [Trait("Categoria", "Distribuições por ativos")]
        public void MethodName()
        {
            // Arrange
            DistribuicaoPorAtivo distribuicao = new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(25));
            // Act
            //distribuicao.AtualizarOrientacao();
            // Assert


        }

    }
}
