using AutoMapper;
using IHolder.Business.Base;
using IHolder.Business.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Business.Handlers
{
    public class UsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, Response>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Usuario> _repository;
        private readonly IResponse _response;

        public UsuarioHandler(IMapper mapper, IRepositoryBase<Usuario> repository, IResponse response)
        {
            _mapper = mapper;
            _repository = repository;
            _response = response;
        }

        public async Task<Response> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            await _repository.Insert(_mapper.Map<Usuario>(request));
            return _response.Success("Usuario cadastrado com sucesso.");
        }

    }
}
