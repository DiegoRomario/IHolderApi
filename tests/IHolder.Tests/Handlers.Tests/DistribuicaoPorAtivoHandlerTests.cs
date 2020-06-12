using System;
using System.Collections.Generic;
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


namespace IHolder.Tests.Handlers.Tests
{
    public class DistribuicaoPorAtivoHandlerTests
    {
        private readonly AlterarDistribuicaoPorAtivoCommand command;
        private readonly AutoMocker mocker;
        private readonly Mock<IRepositoryBase<DistribuicaoPorAtivo>> distribuicaoRepository;
        private readonly Mock<IMapper> mapper;
        private readonly Mock<IAtivoEmCarteiraRepository> AtivoEmCarteiraRepository;
        private readonly Mock<IRepositoryBase<Ativo>> ativoRepository;
        private readonly Mock<IHandlerBase> handlerBase;
        private IEnumerable<DistribuicaoPorAtivo> distribuicoes;
        public DistribuicaoPorAtivoHandlerTests()
        {
            command = new AlterarDistribuicaoPorAtivoCommand(Guid.NewGuid(),Guid.NewGuid(), 1);
            mocker = new AutoMocker();
            distribuicaoRepository = mocker.GetMock<IRepositoryBase<DistribuicaoPorAtivo>>();
            mapper = mocker.GetMock<IMapper>();
            AtivoEmCarteiraRepository = mocker.GetMock<IAtivoEmCarteiraRepository>();
            ativoRepository = mocker.GetMock<IRepositoryBase<Ativo>>();
            handlerBase = mocker.GetMock<IHandlerBase>();
            distribuicoes = new List<DistribuicaoPorAtivo>();
        }

        [Fact(DisplayName = "Cadastro Distribuição com % excedente")]
        [Trait("Distribuicao Por Ativo", "Distribuicao Testes")]
        public async Task DistribuicaoPorAtivo_DadoPercentualObjetivoQueSomadoAoAcumuladoUltrapassa100_DeveImpedirOCadastro()
        {
            // Arrange             
            distribuicoes = new List<DistribuicaoPorAtivo>() {
                new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(100))
            };
            distribuicaoRepository.Setup(r => r.GetManyBy(It.IsAny<Expression<Func<DistribuicaoPorAtivo, bool>>>())).Returns(Task.FromResult(distribuicoes));
            handlerBase.Setup(h => h.HasNotification()).Returns(true);
            var handler = new DistribuicaoPorAtivoHandler(mapper.Object, distribuicaoRepository.Object, AtivoEmCarteiraRepository.Object, handlerBase.Object);

            // Act
            var response = await handler.Handle(command, CancellationToken.None);

            // Assert
            handlerBase.Verify(h => h.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%"), Times.Once);
            Assert.False(response);
        }

        [Fact(DisplayName = "Cadastro Distribuição com % regular")]
        [Trait("Distribuicao Por Ativo", "Distribuicao Testes")]
        public async Task MethodName()
        {
            // Arrange
            distribuicoes = new List<DistribuicaoPorAtivo>() {
                new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(50))
            };
            distribuicaoRepository.Setup(r => r.GetManyBy(It.IsAny<Expression<Func<DistribuicaoPorAtivo, bool>>>())).Returns(Task.FromResult(distribuicoes));
            handlerBase.Setup(h => h.HasNotification()).Returns(false);
            distribuicaoRepository.Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            var handler = new DistribuicaoPorAtivoHandler(mapper.Object, distribuicaoRepository.Object, AtivoEmCarteiraRepository.Object, handlerBase.Object);
            // Act
            var response = await handler.Handle(command, CancellationToken.None);
            // Assert
            handlerBase.Verify(h => h.PublishNotification("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%"), Times.Never);
            Assert.True(response);

        }

    }
}
