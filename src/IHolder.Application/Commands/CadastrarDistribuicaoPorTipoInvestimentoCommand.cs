using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarDistribuicaoPorTipoInvestimentoCommand : Command<bool>
    {
        public CadastrarDistribuicaoPorTipoInvestimentoCommand(Guid tipoInvestimentoId, decimal percentualObjetivo)
        {
            TipoInvestimentoId = tipoInvestimentoId;
            PercentualObjetivo = percentualObjetivo;
        }

        public Guid TipoInvestimentoId { get; set; }
        public decimal PercentualObjetivo { get; set; }


    }

    public class CadastrarDistribuicaoPorTipoInvestimentoCommandValidator : AbstractValidator<CadastrarDistribuicaoPorTipoInvestimentoCommand>
    {
        public CadastrarDistribuicaoPorTipoInvestimentoCommandValidator()
        {
            RuleFor(c => c.TipoInvestimentoId).NotEmpty().WithMessage("O tipo de investimento deve ser informado");
            
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}
