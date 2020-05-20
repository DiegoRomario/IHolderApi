using FluentValidation;
using IHolder.Application.Base;
using IHolder.Domain.Enumerators;
using MediatR;
using Newtonsoft.Json;

namespace IHolder.Application.Commands
{
    public class CadastrarUsuarioCommand : Command<bool>
    {
        [JsonConstructor]
        public CadastrarUsuarioCommand(string nome, string email, string senha, string confirmacaoSenha, EGenero genero)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
            Genero = genero;
        }
        public EGenero Genero { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }

    }

    public class CadastrarUsuarioCommandValidator : AbstractValidator<CadastrarUsuarioCommand>
    {
        public CadastrarUsuarioCommandValidator()
        {
            RuleFor(c => c.Email).EmailAddress().WithMessage("O login do usuário deve ser um e-mail válido");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome do usuário deve ser preenchido");
            RuleFor(c => c.Genero).NotEmpty().WithMessage("O genero do usuário deve ser preenchido");
            RuleFor(c => c.Senha).MinimumLength(6).WithMessage("A senha do usuário deve ter no mínimo 6 caracteres");
            RuleFor(c => c.ConfirmacaoSenha).Equal(o => o.Senha).WithMessage("A confirmação de senha deve ter o mesmo conteúdo da senha");
        }
    }

}
