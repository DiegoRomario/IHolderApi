using FluentValidation;
using IHolder.Business.Base;
using IHolder.Domain.Enumerators;
using MediatR;

namespace IHolder.Business.Commands
{
    public class CadastrarUsuarioCommand : IRequest<Response>
    {
        public CadastrarUsuarioCommand(string nome, string email, string senha, string confirmacaoSenha, EGenero genero)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
            Genero = genero;
        }
        public EGenero Genero { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string ConfirmacaoSenha { get; private set; }
    }

    public class CadastrarUsuarioValidator : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioValidator()
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage("O login do usuário deve ser um e-mail válido");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do usuário deve ser preenchido");
            RuleFor(c => c.Genero).NotEmpty().WithMessage("O genero do usuário deve ser preenchido");
            RuleFor(c => c.Senha).MinimumLength(6).WithMessage("A senha do usuário deve ter no mínimo 6 caracteres");
            RuleFor(c => c.ConfirmacaoSenha).Equal(o => o.Senha).WithMessage("A confirmação de senha deve ter o mesmo conteúdo da senha");
        }
    }

}
