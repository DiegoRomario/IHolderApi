using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Moq.AutoMock;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using AutoMapper;
using IHolder.Domain.Interfaces;
using IHolder.Application.Handlers;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using IHolder.Domain.ValueObjects;
using System.Linq;

namespace IHolder.Tests.Handlers.Tests
{
    public class DistribuicaoPorAtivoHandlerTests
    {

        [Fact(DisplayName = "Cadastro Distribuição Por Ativo")]
        [Trait("DistribuicaoPorAtivo", "Distribuicao Testes")]
        public async Task DistribuicaoPorAtivo_DadoPercentualObjetivoMaiorQue100_DeveImpedirOCadastro()
        {
            // Arrange  
            var command = new CadastrarDistribuicaoPorAtivoCommand(Guid.NewGuid(), 1);
            var mocker = new AutoMocker();
            var distribuicaoRepository = mocker.GetMock<IRepositoryBase<DistribuicaoPorAtivo>>();
            IEnumerable<DistribuicaoPorAtivo> distribuicoes = new List<DistribuicaoPorAtivo>() {
                new DistribuicaoPorAtivo(Guid.NewGuid(),Guid.NewGuid(), new Valores(50)),
                new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(50))
            };
            distribuicaoRepository.Setup(r => r.GetManyBy(It.IsAny<Expression<Func<DistribuicaoPorAtivo, bool>>>())).Returns(Task.FromResult(distribuicoes));
            var mapper = mocker.GetMock<IMapper>();
            var aporteRepository = mocker.GetMock<IAporteRepository>();
            var handlerBase = mocker.GetMock<IHandlerBase>();

            var handler = new DistribuicaoPorAtivoHandler(mapper.Object, distribuicaoRepository.Object, aporteRepository.Object, handlerBase.Object);

            // Act

            var response = await handler.Handle(command, CancellationToken.None);
            // Assert

            handlerBase.Verify(h => h.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%"), Times.Once);
            Assert.False(response);

        }

    }
}
