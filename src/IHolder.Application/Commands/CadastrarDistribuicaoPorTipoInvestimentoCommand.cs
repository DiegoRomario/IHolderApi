using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarDistribuicaoPorTipoInvestimentoCommand : Command<bool>
    {
        public CadastrarDistribuicaoPorTipoInvestimentoCommand(Guid tipoInvestimentoId, Guid usuarioId, decimal percentualObjetivo)
        {
            TipoInvestimentoId = tipoInvestimentoId;
            this.UsuarioId = usuarioId;
            PercentualObjetivo = percentualObjetivo;
        }

        public Guid TipoInvestimentoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal PercentualObjetivo { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarDistribuicaoPorTipoInvestimentoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarDistribuicaoPorTipoInvestimentoCommandValidator : AbstractValidator<CadastrarDistribuicaoPorTipoInvestimentoCommand>
    {
        public CadastrarDistribuicaoPorTipoInvestimentoCommandValidator()
        {
            RuleFor(c => c.TipoInvestimentoId).NotEmpty().WithMessage("O tipo de investimento deve ser informado");
            RuleFor(c => c.UsuarioId).NotEmpty().WithMessage("O usuario deve ser informado");
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}
