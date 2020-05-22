using IHolder.Application.Commands;
using IHolder.Application.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using AutoMapper;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Application.Base;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using IHolder.Domain.ValueObjects;

namespace IHolder.Tests.Handlers.Tests
{
    public class AtivoHandlerTests
    {

        [Fact(DisplayName = "Cadastro Ativo")]
        [Trait("Aporte", "Ativo Trait Testes")]
        public async Task AtivoHandler_DadoUmComandoValido_DeveCadastrarAtivo ()
        {
            // Arrange
            CadastrarAtivoCommand command = new CadastrarAtivoCommand(new Guid(), "Empresa", "Empresa legal", "WEGE3", 10);
            var mapper = new Mock<IMapper>();
            var repository = new Mock<IRepositoryBase<Ativo>>();
            repository.Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            var handlerBase = new Mock<IHandlerBase>();
            var handler = new AtivoHandler(repository.Object, handlerBase.Object, mapper.Object);
            Ativo ativo = mapper.Object.Map<Ativo>(command);
            // Act
            bool retorno = await handler.Handle(command, CancellationToken.None);
            // Assert
            repository.Verify(r => r.Insert(ativo), Times.Once);

        }
    }
}
