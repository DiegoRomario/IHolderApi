using AutoMapper;
using IHolder.Application.Auxiliaries;
using IHolder.Application.Base;
using IHolder.Application.Commands;
using IHolder.Domain.DomainObjects;
using IHolder.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IHolder.Application.Handlers
{
    public class UsuarioHandler : IRequestHandler<CadastrarUsuarioCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Usuario> _repository;
        private readonly IHandlerBase _handlerBase;
        private readonly ICryptography _cryptography;

        public UsuarioHandler(IMapper mapper, IRepositoryBase<Usuario> repository, IHandlerBase handlerBase, ICryptography cryptography)
        {
            _mapper = mapper;
            _repository = repository;
            _handlerBase = handlerBase;
            _cryptography = cryptography;
        }

        public async Task<bool> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            Usuario usuario = await _repository.GetBy(u => (u.Email == request.Email));
            if (usuario != null) { 
                _handlerBase.PublishNotification("O e-mail informado já está cadastrado em nossa base de dados");
                return false;
            }

            request.Senha = _cryptography.PasswordEncrypt(request.Senha);
            _repository.Insert(_mapper.Map<Usuario>(request));
            return await _repository.UnitOfWork.Commit();
        }
    }
}