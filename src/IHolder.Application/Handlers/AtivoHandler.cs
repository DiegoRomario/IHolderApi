using AutoMapper;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Handlers
{
    public class AtivoHandler : IRequestHandler<CadastrarAtivoCommand, bool>
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

        public Task<bool> Handle(CadastrarAtivoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
