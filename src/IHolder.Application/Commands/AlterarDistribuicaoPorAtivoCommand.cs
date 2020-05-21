using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarDistribuicaoPorAtivoCommand : Command<bool>
    {
        public AlterarDistribuicaoPorAtivoCommand(Guid id, Guid ativoId, decimal percentualObjetivo)
        {
            Id = id;
            AtivoId = ativoId;
            PercentualObjetivo = percentualObjetivo;
        }

        public Guid Id { get; set; }
        public Guid AtivoId { get; set; }
        public decimal PercentualObjetivo { get; set; }
    }

    public class AlterarDistribuicaoPorAtivoCommandValidator : AbstractValidator<AlterarDistribuicaoPorAtivoCommand>
    {
        public AlterarDistribuicaoPorAtivoCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O ID da distribuição deve ser informada");
            RuleFor(c => c.AtivoId).NotEmpty().WithMessage("O ativo deve ser informado");            
            RuleFor(c => c.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O percentual objetivo deve ser entre 1% e 100%");
        }
    }
}