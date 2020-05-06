using FluentValidation;
using IHolder.Business.Repositories.Base;
using System;

namespace IHolder.Business.Entities.Validations
{
    public class UsuarioValidation : AbstractValidator<Usuario>
    {
        private readonly IRepositoryBase<Usuario> _repositoryBase;

        public UsuarioValidation(IRepositoryBase<Usuario> repositoryBase)
        {
            _repositoryBase = repositoryBase;
            RuleFor(t => t).Must(t => UsuarioCadastrado(t.Id, t.Email)).WithMessage("E-mail, CPF e/ou Ceular já cadastrado(s) em nossa base de dados.");
        }

        public bool UsuarioCadastrado (Guid id, string email)
        {
            Usuario response = _repositoryBase.GetBy(u => (u.Email == email) && u.Id != id).Result;
            return response == null;
        }
    }
}
