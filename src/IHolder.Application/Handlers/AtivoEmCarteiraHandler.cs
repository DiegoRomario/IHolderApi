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
    public class AtivoEmCarteiraHandler : IRequestHandler<CadastrarAtivoEmCarteiraCommand, bool>,
        IRequestHandler<AlterarAtivoEmCarteiraCommand, bool>
    {
        private readonly IRepositoryBase<AtivoEmCarteira> _repository;
        private readonly IHandlerBase _handlerBase;
        private readonly IMapper _mapper;

        public AtivoEmCarteiraHandler(IRepositoryBase<AtivoEmCarteira> repository, IHandlerBase handlerBase, IMapper mapper)
        {
            _repository = repository;
            _handlerBase = handlerBase;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CadastrarAtivoEmCarteiraCommand request, CancellationToken cancellationToken)
        {
            AtivoEmCarteira entity = _mapper.Map<AtivoEmCarteira>(request);
            _repository.Insert(entity);
            return await _repository.UnitOfWork.Commit();
        }

        public async Task<bool> Handle(AlterarAtivoEmCarteiraCommand request, CancellationToken cancellationToken)
        {
            _repository.Update(_mapper.Map<AtivoEmCarteira>(request));
            return await _repository.UnitOfWork.Commit();
        }
    }
}
