using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarDistribuicaoPorProdutoCommand : Command<bool>
    {
        public CadastrarDistribuicaoPorProdutoCommand(Guid produtoId, Guid usuarioId, decimal percentualObjetivo)
        {
            ProdutoId = produtoId;
            this.UsuarioId = usuarioId;
            PercentualObjetivo = percentualObjetivo;
        }
        public Guid ProdutoId { get; set; }
        public Guid UsuarioId { get; set; }
        public decimal PercentualObjetivo { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarDistribuicaoPorProdutoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class CadastrarDistribuicaoPorProdutoCommandValidator : AbstractValidator<CadastrarDistribuicaoPorProdutoCommand>
    {
        public CadastrarDistribuicaoPorProdutoCommandValidator()
        {
            RuleFor(c => c.ProdutoId).NotEmpty().WithMessage("O Produto deve ser informado");
            RuleFor(c => c.UsuarioId).NotEmpty().WithMessage("O usuario deve ser informado");
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}
