using FluentValidation;
using IHolder.Business.Base;
using MediatR;
using System;

namespace IHolder.Business.Commands
{
    public class CadastrarDistribuicaoPorTipoInvestimentoCommand : IRequest<Response>
    {
        public CadastrarDistribuicaoPorTipoInvestimentoCommand(Guid tipoInvestimentoId, Guid usuarioId, decimal percentualObjetivo)
        {
            TipoInvestimentoId = tipoInvestimentoId;
            this.usuarioId = usuarioId;
            PercentualObjetivo = percentualObjetivo;
        }

        public Guid TipoInvestimentoId { get; set; }
        public Guid usuarioId { get; set; }
        public decimal PercentualObjetivo { get; set; }

    }

    public class DefinirDistribuicaoPorTipoInvestimentoCommandValidator : AbstractValidator<CadastrarDistribuicaoPorTipoInvestimentoCommand>
    {
        public DefinirDistribuicaoPorTipoInvestimentoCommandValidator()
        {
            RuleFor(c => c.TipoInvestimentoId).NotEmpty().WithMessage("O tipo de investimento deve ser informado");
            RuleFor(c => c.usuarioId).NotEmpty().WithMessage("O usuario deve ser informado");
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}
