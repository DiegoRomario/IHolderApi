using AutoMapper;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using IHolder.Application.Handlers;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using IHolder.Domain.Interfaces;
using IHolder.Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;


namespace IHolder.Tests.Handlers.Tests
{
    public class DistribuicaoPorAtivoHandlerTests
    {
        AlterarDistribuicaoPorAtivoCommand _alterarDistribuicaoPorAtivoCommand;

        private IMapper _mapper { get { return MapperMock.Object; } }
        private IRepositoryBase<DistribuicaoPorAtivo> _distribuicaoRepository { get { return DistribuicaoPorAtivoRepositoryMock.Object; } }
        private IAtivoEmCarteiraRepository _ativoEmCarteiraRepository { get { return AtivoEmCarteiraRepositoryMock.Object; } }
        private IHandlerBase _handlerBase { get { return HandlerBaseMock.Object; } }

        private DistribuicaoPorAtivo _distribuicaoPorAtivo;


        Mock<IMapper> MapperMock;
        Mock<IRepositoryBase<DistribuicaoPorAtivo>> DistribuicaoPorAtivoRepositoryMock;
        Mock<IAtivoEmCarteiraRepository> AtivoEmCarteiraRepositoryMock;
        Mock<IHandlerBase> HandlerBaseMock;
        
        public DistribuicaoPorAtivoHandlerTests()
        {
            _distribuicaoPorAtivo = new DistribuicaoPorAtivo(Guid.NewGuid(), Guid.NewGuid(), new Valores(10));
            _alterarDistribuicaoPorAtivoCommand = new AlterarDistribuicaoPorAtivoCommand(Guid.NewGuid(), Guid.NewGuid(), 10);
            MapperMock = new Mock<IMapper>();
            DistribuicaoPorAtivoRepositoryMock = new Mock<IRepositoryBase<DistribuicaoPorAtivo>>();
            AtivoEmCarteiraRepositoryMock = new Mock<IAtivoEmCarteiraRepository>();
            HandlerBaseMock = new Mock<IHandlerBase>();
            DistribuicaoPorAtivoRepositoryMock.Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

        }

        [Fact(DisplayName = "Alteração distribuição por ativos")]
        [Trait("Categoria", "Distribuição por ativos")]
        public async Task DadoUmCommandoValido_SeNaoExistirUmRegistroIgualParaOMesmoIdOuUltrapassarOLimitePercentual_DeveAtualizarRegistrosCorretamente()
        {
            // Arrange
            DistribuicaoPorAtivoHandler handler = new DistribuicaoPorAtivoHandler(_mapper, _distribuicaoRepository, _ativoEmCarteiraRepository, _handlerBase);
            DistribuicaoPorAtivoRepositoryMock.Setup(r =>
                                            r.GetBy(It.IsAny<Expression<Func<DistribuicaoPorAtivo, bool>>>()))
                                            .Returns(Task.FromResult((DistribuicaoPorAtivo)null));

            IEnumerable<DistribuicaoPorAtivo> lista = new List<DistribuicaoPorAtivo>() { _distribuicaoPorAtivo };

            DistribuicaoPorAtivoRepositoryMock.Setup(r =>
                                            r.GetManyBy(It.IsAny<Expression<Func<DistribuicaoPorAtivo, bool>>>()))
                                            .Returns(Task.FromResult(lista));
            // Act
            await handler.Handle(_alterarDistribuicaoPorAtivoCommand, CancellationToken.None);
            // Assert
            HandlerBaseMock.Verify(h => h.PublishNotification(It.IsAny<string>()), Times.Never);
            DistribuicaoPorAtivoRepositoryMock.Verify(d => d.Update(It.IsAny<DistribuicaoPorAtivo>()), Times.Once);
        }

    }
}
