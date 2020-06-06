using IHolder.Application.Commands;
using IHolder.Application.Handlers;
using System;
using Xunit;
using Moq;
using AutoMapper;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Application.Base;
using System.Threading;
using System.Threading.Tasks;
using IHolder.Domain.ValueObjects;
using System.Linq.Expressions;

namespace IHolder.Tests.Handlers.Tests
{
    public class AtivoHandlerTests
    {
        CadastrarAtivoCommand command = new CadastrarAtivoCommand(Guid.NewGuid(), "Empresa", "Empresa legal", "TEST3", 10);
        Mock<IMapper> mapper = new Mock<IMapper>();
        Mock<IRepositoryBase<Ativo>> repository = new Mock<IRepositoryBase<Ativo>>();
        Mock<IRepositoryBase<DistribuicaoPorAtivo>> distribuicaoRepository = new Mock<IRepositoryBase<DistribuicaoPorAtivo>>();
        Mock<IHandlerBase> handlerBase = new Mock<IHandlerBase>();
        public AtivoHandlerTests()
        {
            repository.Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            
        }
        [Fact(DisplayName = "Cadastro Ativo")]
        [Trait("Ativo", "Ativo Testes")]
        public async Task AtivoHandler_DadoUmComandoValido_DeveCadastrarAtivo()
        {
            // Arrange
            var handler = new AtivoHandler(repository.Object, handlerBase.Object, mapper.Object, distribuicaoRepository.Object);
            Ativo ativo = mapper.Object.Map<Ativo>(command);
            // Act
            bool retorno = await handler.Handle(command, CancellationToken.None);
            // Assert
            repository.Verify(r => r.Insert(ativo), Times.Once);

        }

        [Fact(DisplayName = "Cadastro Ativo Existente")]
        [Trait("Ativo", "Ativo Testes")]
        public async Task AtivoHandler_DadoUmComandoValidoDeUmAtivoJaExistente_DevePublicarNotificacao()
        {
            // Arrange
            Ativo ativo = new Ativo(Guid.NewGuid(), new Informacoes("Empresa", "Empresa legal"), "TEST3", 10, Guid.NewGuid());
            repository.Setup(r => r.GetBy(It.IsAny<Expression<Func<Ativo, bool>>>())).Returns(Task.FromResult(ativo));
            var handler = new AtivoHandler(repository.Object, handlerBase.Object, mapper.Object, distribuicaoRepository.Object);

            // Act
            bool retorno = await handler.Handle(command, CancellationToken.None);
            // Assert

            handlerBase.Verify(b => b.PublishNotification("Já existe um ativo cadastrado com o mesmo Ticker"), Times.Once);
            Assert.False(retorno);

        }


        [Fact(DisplayName = "Cadastro Ativo Command")]
        [Trait("Ativo", "Ativo Testes")]
        public async Task AtivoCommand_DadoUmComandoInvalido_DeveRetornarErros()
        {
            // Arrange
            var validator = new CadastrarAtivoCommandValidator();
            var command = new CadastrarAtivoCommand(Guid.NewGuid(), "Empresa", "Empresa legal", "TEST3", -1);

            // Act
            var validationResult = await validator.ValidateAsync(command);

            // Assert
            Assert.Equal(1, validationResult.Errors.Count);
        }


    }
}
