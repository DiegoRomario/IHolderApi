using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarDistribuicaoPorProdutoCommand : Command<bool>
    {
        public AlterarDistribuicaoPorProdutoCommand(Guid id, Guid tipoDistribuicaoId, decimal percentualObjetivo)
        {
            Id = id;
            PercentualObjetivo = percentualObjetivo;
            TipoDistribuicaoId = tipoDistribuicaoId;
        }

        public Guid Id { get; set; }
        public Guid TipoDistribuicaoId { get; set; }
        public decimal PercentualObjetivo { get; set; }

    }

    public class AlterarDistribuicaoPorProdutoCommandValidator : AbstractValidator<AlterarDistribuicaoPorProdutoCommand>
    {
        public AlterarDistribuicaoPorProdutoCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O ID da distribuição deve ser informada");
            RuleFor(c => c.TipoDistribuicaoId).NotEmpty().WithMessage("O produto deve ser informado");            
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(0, 100).WithMessage("O percentual objetivo deve ser entre 0 e 100%");
        }
    }
}