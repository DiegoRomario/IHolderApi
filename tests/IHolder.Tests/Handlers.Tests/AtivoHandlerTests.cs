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
using IHolder.Domain.Enumerators;

namespace IHolder.Tests.Handlers.Tests
{
    public class AtivoHandlerTests
    {
        CadastrarAtivoCommand cadastrarAtivoCommand = new CadastrarAtivoCommand(Guid.NewGuid(), "Empresa", "Empresa legal", "TEST3", 10);
        AlterarAtivoCommand alterarAtivoCommand = new AlterarAtivoCommand(Guid.NewGuid(), Guid.NewGuid(), "Empresa", "Empresa da hora", "TEST4", 20.55m, DateTime.Now, ESituacao.Oportunidade);
        Mock<IMapper> mapper = new Mock<IMapper>();
        Mock<IRepositoryBase<Ativo>> repository = new Mock<IRepositoryBase<Ativo>>();
        Mock<IRepositoryBase<DistribuicaoPorAtivo>> distribuicaoRepository = new Mock<IRepositoryBase<DistribuicaoPorAtivo>>();
        Mock<IHandlerBase> handlerBase = new Mock<IHandlerBase>();
        AtivoHandler handler;
        Ativo ativo;
        public AtivoHandlerTests()
        {
            ativo = new Ativo(Guid.NewGuid(), new Informacoes("Empresa", "Empresa legal"), "TEST3", 10, Guid.NewGuid());
            repository.Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));
            mapper.Setup(m => m.Map<Ativo>(cadastrarAtivoCommand)).Returns(new Ativo(Guid.NewGuid(), new Informacoes("Empresa","Empresa legal"), "TEST3", 20.20m, Guid.NewGuid()));
            handler = new AtivoHandler(repository.Object, handlerBase.Object, mapper.Object, distribuicaoRepository.Object);
        }
        [Fact(DisplayName = "Cadastro Ativo")]
        [Trait("Ativo", "Ativo Cadastro")]
        public async Task DadoUmComandoValido_DeveCadastrarAtivo()
        {
            // Arrange           
            // Act
            bool retorno = await handler.Handle(cadastrarAtivoCommand, CancellationToken.None);
            // Assert
            repository.Verify(r => r.Insert(It.IsAny<Ativo>()), Times.Once);
            handlerBase.Verify(h => h.PublishNotification(It.IsAny<string>()), Times.Never);

        }

        [Fact(DisplayName = "Cadastro Ativo Existente")]
        [Trait("Ativo", "Ativo Cadastro")]
        public async Task DadoUmComandoValidoDeUmAtivoJaExistente_DevePublicarNotificacao()
        {
            // Arrange
            repository.Setup(r => r.GetBy(It.IsAny<Expression<Func<Ativo, bool>>>())).Returns(Task.FromResult(ativo));
            // Act
            bool retorno = await handler.Handle(cadastrarAtivoCommand, CancellationToken.None);
            // Assert
            handlerBase.Verify(b => b.PublishNotification("Já existe um ativo cadastrado com o mesmo Ticker"), Times.Once);
            Assert.False(retorno);

        }

        [Fact(DisplayName = "Alteração Ativo")]
        [Trait("Ativo", "Ativo Alteração")]
        public async Task DadoUmComandoValido_DeveAlterarOAtivo()
        {
            // Arrange
            // Act
            bool retorno = await handler.Handle(alterarAtivoCommand, CancellationToken.None);
            // Assert
            repository.Verify(r => r.Update(It.IsAny<Ativo>()), Times.Once);
            handlerBase.Verify(h => h.PublishNotification(It.IsAny<string>()), Times.Never);

        }

        [Fact(DisplayName = "Alterar Ativo Existente")]
        [Trait("Ativo", "Ativo Alteração")]
        public async Task DadoUmComandoValidoDeUmAtivoJaExistenteComIdDiferenteDoAtual_DevePublicarNotificacao()
        {
            // Arrange
            repository.Setup(r => r.GetBy(It.IsAny<Expression<Func<Ativo, bool>>>())).Returns(Task.FromResult(ativo));
            // Act
            bool retorno = await handler.Handle(alterarAtivoCommand, CancellationToken.None);
            // Assert
            handlerBase.Verify(b => b.PublishNotification("Já existe um ativo cadastrado com o mesmo Ticker"), Times.Once);
            Assert.False(retorno);
        }
    }
}
