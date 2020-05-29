using AutoMapper;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Handlers
{
    public class AporteHandler : IRequestHandler<CadastrarAporteCommand, bool>,
        IRequestHandler<AlterarAporteCommand, bool>
    {
        private readonly IRepositoryBase<Aporte> _repository;
        private readonly IHandlerBase _handlerBase;
        private readonly IMapper _mapper;

        public AporteHandler(IRepositoryBase<Aporte> repository, IHandlerBase handlerBase, IMapper mapper)
        {
            _repository = repository;
            _handlerBase = handlerBase;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CadastrarAporteCommand request, CancellationToken cancellationToken)
        {
            _repository.Insert(_mapper.Map<Aporte>(request));
            return await _repository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AlterarAporteCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(_mapper.Map<Aporte>(request));
            return await _repository.UnitOfWork.Commit();
        }
    }
}
