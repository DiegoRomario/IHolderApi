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
    public class AtivoHandler : IRequestHandler<CadastrarAtivoCommand, bool>,
        IRequestHandler<AlterarAtivoCommand, bool>
    {
        private readonly IRepositoryBase<Ativo> _repository;
        private readonly IHandlerBase _handlerBase;
        private readonly IMapper _mapper;

        public AtivoHandler(IRepositoryBase<Ativo> repository, IHandlerBase handlerBase, IMapper mapper)
        {
            _repository = repository;
            _handlerBase = handlerBase;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CadastrarAtivoCommand request, CancellationToken cancellationToken)
        {
            if (TicketJaCadastrado(request.Ticker))
            {
                _handlerBase.PublishNotification("Já existe um ativo cadastrado com o mesmo Ticker");
                return false;
            }

            _repository.Insert(_mapper.Map<Ativo>(request));
            return await _repository.UnitOfWork.Commit();
        }

        private bool TicketJaCadastrado(string ticker)
        {
            return _repository.GetBy(a => a.Ticker == ticker).Result != null;
        }

        public async Task<bool> Handle(AlterarAtivoCommand request, CancellationToken cancellationToken)
        {
            if (TicketJaCadastrado(request.Ticker))
            {
                _handlerBase.PublishNotification("Já existe um ativo cadastrado com o mesmo Ticker");
                return false;
            }

            _repository.Update(_mapper.Map<Ativo>(request));
            return await _repository.UnitOfWork.Commit();
        }
    }
}
