using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarDistribuicaoPorTipoInvestimentoCommand : Command<bool>
    {
        public AlterarDistribuicaoPorTipoInvestimentoCommand(Guid id, Guid tipoInvestimentoId, decimal percentualObjetivo)
        {
            Id = id;
            PercentualObjetivo = percentualObjetivo;
            TipoInvestimentoId = tipoInvestimentoId;
        }

        public Guid Id { get; set; }
        public Guid TipoInvestimentoId { get; set; }
        public decimal PercentualObjetivo { get; set; }
    }

    public class AlterarDistribuicaoPorTipoInvestimentoCommandValidator : AbstractValidator<AlterarDistribuicaoPorTipoInvestimentoCommand>
    {
        public AlterarDistribuicaoPorTipoInvestimentoCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O ID da distribuição deve ser informada");
            RuleFor(c => c.TipoInvestimentoId).NotEmpty().WithMessage("O tipo de investimento deve ser informado");            
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}