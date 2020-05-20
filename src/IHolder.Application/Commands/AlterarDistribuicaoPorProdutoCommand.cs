using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarDistribuicaoPorProdutoCommand : Command<bool>
    {
        public AlterarDistribuicaoPorProdutoCommand(Guid id, Guid produtoId, Guid usuarioId, decimal percentualObjetivo)
        {
            Id = id;
            UsuarioId = usuarioId;
            PercentualObjetivo = percentualObjetivo;
            ProdutoId = produtoId;
        }

        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal PercentualObjetivo { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AlterarDistribuicaoPorProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AlterarDistribuicaoPorProdutoCommandValidator : AbstractValidator<AlterarDistribuicaoPorProdutoCommand>
    {
        public AlterarDistribuicaoPorProdutoCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O ID da distribuição deve ser informada");
            RuleFor(c => c.ProdutoId).NotEmpty().WithMessage("O produto deve ser informado");
            RuleFor(c => c.UsuarioId).NotEmpty().WithMessage("O usuario deve ser informado");
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}