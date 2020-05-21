using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarDistribuicaoPorProdutoCommand : Command<bool>
    {
        public CadastrarDistribuicaoPorProdutoCommand(Guid produtoId, decimal percentualObjetivo)
        {
            ProdutoId = produtoId;
            PercentualObjetivo = percentualObjetivo;
        }
        public Guid ProdutoId { get; set; }
        public decimal PercentualObjetivo { get; set; }

    }

    public class CadastrarDistribuicaoPorProdutoCommandValidator : AbstractValidator<CadastrarDistribuicaoPorProdutoCommand>
    {
        public CadastrarDistribuicaoPorProdutoCommandValidator()
        {
            RuleFor(c => c.ProdutoId).NotEmpty().WithMessage("O Produto deve ser informado");
            
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}
