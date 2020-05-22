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
        [Theory(DisplayName = "Atualizar Orientação")]
        [Trait("Distribuição Por Ativo", "Distribuição Por Ativo Trait Testes")]
        [InlineData(10, 1000, 100000, EOrientacao.Buy)]
        [InlineData(10, 20000, 100000, EOrientacao.Hold)]
        public void DistribuicaoPorAtivo_DadoAtivoComSituacaoDiferenteDeQuarentena_AOrientacaoSeraBuyOuHold
            (decimal percentualObjetivo,
            decimal valorTotalPorAtivo,
            decimal valorTotalGeral
            , EOrientacao orientacao)
        {
            // Arrange
            DistribuicaoPorAtivo distribuicaoPorAtivo =
                new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(percentualObjetivo));

            distribuicaoPorAtivo.AlterarAtivo (new Ativo(Guid.NewGuid(), new Informacoes("teste", "teste"), "teste", 10, new Guid()));
            // Act
            distribuicaoPorAtivo.AtualizarOrientacao(valorTotalPorAtivo, valorTotalGeral);
            // Asset
            Assert.Equal(orientacao, distribuicaoPorAtivo.Orientacao);
        }

        //public void DistribuicaoPorAtivo_DadoPercentualDiferencaMaiorQue1_AOrientacaoSeraParaComprar()
        //{
        //    // Arrange
        //    DistribuicaoPorativo distribuicaoPorAtivo =
        //        new DistribuicaoPorativo(Guid.NewGuid(), Guid.NewGuid(), 10, 6500);
        //    // Act
        //    distribuicaoPorAtivo.AtualizarOrientacao(-3.5M);
        //    // Asset
        //    Assert.Equal(EOrientacao.Manter, distribuicaoPorAtivo.Orientacao);
        //}

    }
}
