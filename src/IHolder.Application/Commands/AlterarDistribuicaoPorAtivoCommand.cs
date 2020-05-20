using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarDistribuicaoPorAtivoCommand : Command<bool>
    {
        public AlterarDistribuicaoPorAtivoCommand(Guid id, Guid distribuicaoPorProdutoId, Guid ativoId, Guid usuarioId, decimal percentualObjetivo)
        {
            Id = id;
            UsuarioId = usuarioId;
            PercentualObjetivo = percentualObjetivo;
            AtivoId = ativoId;
            DistribuicaoPorProdutoId = distribuicaoPorProdutoId;
        }

        public Guid Id { get; set; }
        public Guid DistribuicaoPorProdutoId { get; set; }
        public Guid AtivoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal PercentualObjetivo { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AlterarDistribuicaoPorAtivoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AlterarDistribuicaoPorAtivoCommandValidator : AbstractValidator<AlterarDistribuicaoPorAtivoCommand>
    {
        public AlterarDistribuicaoPorAtivoCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O ID da distribuição deve ser informada");
            RuleFor(c => c.AtivoId).NotEmpty().WithMessage("O ativo deve ser informado");
            RuleFor(c => c.UsuarioId).NotEmpty().WithMessage("O usuario deve ser informado");
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}