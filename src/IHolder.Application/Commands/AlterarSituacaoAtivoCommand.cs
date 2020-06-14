using FluentValidation;
using IHolder.Application.Base;
using IHolder.Domain.Enumerators;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarSituacaoAtivoCommand : Command<bool>
    {

        public AlterarSituacaoAtivoCommand(Guid id, ESituacao situacao)
        {
            Id = id;
            Situacao = situacao;
        }

        public Guid Id { get; set; }
        public ESituacao Situacao { get; set; }


    }

    public class AlterarSituacaoAtivoCommandValidator : AbstractValidator<AlterarSituacaoAtivoCommand>
    {
        public AlterarSituacaoAtivoCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("O ativo deve ser informado");
            RuleFor(a => a.Situacao).NotEmpty().WithMessage("A situação do ativo deve ser informada");
        }
    }
}
