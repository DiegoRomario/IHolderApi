using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarDistribuicaoPorAtivoCommand : Command<bool>
    {
        public CadastrarDistribuicaoPorAtivoCommand(Guid ativoId, Guid usuarioId, decimal percentualObjetivo)
        {
            AtivoId = ativoId;
            this.UsuarioId = usuarioId;
            PercentualObjetivo = percentualObjetivo;
        }

        public Guid AtivoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal PercentualObjetivo { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarDistribuicaoPorAtivoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarDistribuicaoPorAtivoCommandValidator : AbstractValidator<CadastrarDistribuicaoPorAtivoCommand>
    {
        public CadastrarDistribuicaoPorAtivoCommandValidator()
        {
            RuleFor(c => c.AtivoId).NotEmpty().WithMessage("O ativo deve ser informado");
            RuleFor(c => c.UsuarioId).NotEmpty().WithMessage("O usuario deve ser informado");
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}
