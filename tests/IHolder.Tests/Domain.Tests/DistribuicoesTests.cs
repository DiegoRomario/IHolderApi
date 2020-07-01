using IHolder.Domain.Entities;
using IHolder.Domain.Enumerators;
using IHolder.Domain.ValueObjects;
using System;
using Xunit;

namespace IHolder.Tests.Domain.Tests
{
    public class DistribuicoesTests
    {
        public DistribuicoesTests()
        {

        }

        [Theory(DisplayName = "Atualização de Orientação Por Ativo")]
        [Trait("Categoria", "Distribuições por ativos")]
        [InlineData(25, 2000, 10000, EOrientacao.Buy)]
        [InlineData(10, 8000, 10000, EOrientacao.Sell)]
        [InlineData(50, 6000, 10000, EOrientacao.Hold)]
        public void DadoPercentualObjetivoValorInvestidoPorAtivoEValorTotalInvestido_DeveAtualizarOrientacaoCorretamente
        (decimal percentualObjetivo, decimal valorInvestidoAtivo, decimal valorTotalInvestido, EOrientacao orientacao)
        {
            // Arrange
            DistribuicaoPorAtivo distribuicao = new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(percentualObjetivo));
            Ativo ativo = new Ativo(Guid.NewGuid(), new Informacoes("Empresa Teste", "Caracteristica Teste"), "TEST3", 10, Guid.NewGuid());
            distribuicao.AlterarAtivo(ativo);
            // Act
            distribuicao.AtualizarOrientacao(valorInvestido: valorInvestidoAtivo, ValorTotalInvestido: valorTotalInvestido);
            // Assert
            Assert.Equal(distribuicao.Orientacao, orientacao);

        }


        [Theory(DisplayName = "Atualização de Orientação Por Produtos")]
        [Trait("Categoria", "Distribuições por produtos")]
        [InlineData(10, 3000, 50000, EOrientacao.Buy)]
        [InlineData(20, 10000, 15000, EOrientacao.Sell)]
        [InlineData(15, 1500, 10000, EOrientacao.Hold)]
        public void DadoPercentualObjetivoValorInvestidoPorProdutoEValorTotalInvestido_DeveAtualizarOrientacaoCorretamente
        (decimal percentualObjetivo, decimal valorInvestidoAtivo, decimal valorTotalInvestido, EOrientacao orientacao)
        {
            // Arrange
            DistribuicaoPorProduto distribuicao = new DistribuicaoPorProduto(Guid.NewGuid(), Guid.NewGuid(), new Valores(percentualObjetivo));
            // Act
            distribuicao.AtualizarOrientacao(valorInvestido: valorInvestidoAtivo, ValorTotalInvestido: valorTotalInvestido);
            // Assert
            Assert.Equal(distribuicao.Orientacao, orientacao);
        }


        [Theory(DisplayName = "Atualização de Orientação Por Tipo")]
        [Trait("Categoria", "Distribuições por tipo")]
        [InlineData(50, 15000, 8000000, EOrientacao.Buy)]
        [InlineData(10, 80000, 100000, EOrientacao.Sell)]
        [InlineData(20, 22000, 100000, EOrientacao.Hold)]
        public void DadoPercentualObjetivoValorInvestidoPorTipoEValorTotalInvestido_DeveAtualizarOrientacaoCorretamente
        (decimal percentualObjetivo, decimal valorInvestidoAtivo, decimal valorTotalInvestido, EOrientacao orientacao)
        {
            // Arrange
            DistribuicaoPorTipoInvestimento distribuicao = new DistribuicaoPorTipoInvestimento(Guid.NewGuid(), Guid.NewGuid(), new Valores(percentualObjetivo));
            // Act
            distribuicao.AtualizarOrientacao(valorInvestido: valorInvestidoAtivo, ValorTotalInvestido: valorTotalInvestido);
            // Assert
            Assert.Equal(distribuicao.Orientacao, orientacao);
        }

    }
}
