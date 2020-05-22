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
        [Theory(DisplayName = "Atualizar Orientação Por Ativo")]
        [Trait("Distribuição Por Ativo", "Distribuição Por Ativo Trait Testes")]
        [InlineData(10, 1000, 100000, EOrientacao.Buy)]
        [InlineData(10, 20000, 100000, EOrientacao.Hold)]
        public void DistribuicaoPorAtivo_DadoAtivoComSituacaoDiferenteDeQuarentena_AOrientacaoSeraBuyOuHold
            (decimal percentualObjetivo, decimal valorTotalPorAtivo, decimal valorTotalGeral, EOrientacao orientacao)
        {
            // Arrange
            DistribuicaoPorAtivo distribuicaoPorAtivo =
                new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(percentualObjetivo));

            distribuicaoPorAtivo.AlterarAtivo(new Ativo(Guid.NewGuid(), new Informacoes("teste", "teste"), "teste", 10, new Guid()));
            // Act
            distribuicaoPorAtivo.AtualizarOrientacao(valorTotalPorAtivo, valorTotalGeral);
            // Asset
            Assert.Equal(orientacao, distribuicaoPorAtivo.Orientacao);
        }


        [Theory(DisplayName = "Atualizar Orientação Por Produto")]
        [Trait("Distribuição Por Produto", "Distribuição Por Produto Trait Testes")]
        [InlineData(50, 1000, 100000, EOrientacao.Buy)]
        [InlineData(50, 90000, 100000, EOrientacao.Hold)]
        public void DistribuicaoPorProduto_DadoValorTotalPorProdutoETotalGeral_DeveOrientarCorretamente
        (decimal percentualObjetivo, decimal valorTotalPorProduto, decimal valorTotalGeral, EOrientacao orientacao)
        {
            // Arrange
            DistribuicaoPorProduto distribuicaoPorProduto =
                new DistribuicaoPorProduto(Guid.NewGuid(), Guid.NewGuid(), new Valores(percentualObjetivo));
            // Act
            distribuicaoPorProduto.AtualizarOrientacao(valorTotalPorProduto, valorTotalGeral);
            // Asset
            Assert.Equal(orientacao, distribuicaoPorProduto.Orientacao);
        }

        [Theory(DisplayName = "Atualizar Orientação Por TipoInvestimento")]
        [Trait("Distribuição Por TipoInvestimento", "Distribuição Por TipoInvestimento Trait Testes")]
        [InlineData(50, 1000, 100000, EOrientacao.Buy)]
        [InlineData(50, 90000, 100000, EOrientacao.Hold)]
        public void DistribuicaoPorTipoInvestimento_DadoValorTotalPorTipoInvestimentoETotalGeral_DeveOrientarCorretamente
        (decimal percentualObjetivo, decimal valorTotalPorTipo, decimal valorTotalGeral, EOrientacao orientacao)
        {
            // Arrange
            DistribuicaoPorTipoInvestimento distribuicaoPorTipoInvestimento =
                new DistribuicaoPorTipoInvestimento(Guid.NewGuid(), Guid.NewGuid(), new Valores(percentualObjetivo));
            // Act
            distribuicaoPorTipoInvestimento.AtualizarOrientacao(valorTotalPorTipo, valorTotalGeral);
            // Asset
            Assert.Equal(orientacao, distribuicaoPorTipoInvestimento.Orientacao);
        }


    }
}
