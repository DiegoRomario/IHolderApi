using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarDistribuicaoPorAtivoCommand : Command<bool>
    {
        public CadastrarDistribuicaoPorAtivoCommand(Guid ativoId,decimal percentualObjetivo)
        {
            Id = ativoId;
            PercentualObjetivo = percentualObjetivo;
        }

        public Guid Id { get; set; }
        public decimal PercentualObjetivo { get; set; }

    }

    public class CadastrarDistribuicaoPorAtivoCommandValidator : AbstractValidator<CadastrarDistribuicaoPorAtivoCommand>
    {
        public CadastrarDistribuicaoPorAtivoCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O ativo deve ser informado");
            
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}
