using FluentValidation;
using IHolder.Domain.Interfaces;
using System;
using System.Linq;

namespace IHolder.Domain.Entities.Validations
{
    public class DistribuicaoPorTipoInvestimentoValidation : AbstractValidator<DistribuicaoPorTipoInvestimento>
    {
        private readonly IDistribuicaoPorTipoInvestimentoRepository _distribuicaoPorTipoInvestimentoRepository;
        public DistribuicaoPorTipoInvestimentoValidation(IDistribuicaoPorTipoInvestimentoRepository distribuicaoPorTipoInvestimentoRepository)
        {
            _distribuicaoPorTipoInvestimentoRepository = distribuicaoPorTipoInvestimentoRepository;
            RuleFor(d => d.Valores.PercentualObjetivo).InclusiveBetween(1, 100).WithMessage("O Percentual objetivo deve estar entre {From} e {To}.");
            RuleFor(d => d).Must(d => PercentualObjetivoAcumulado(d.Id, d.Valores.PercentualObjetivo) <= 100).WithMessage("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
        }

        protected decimal PercentualObjetivoAcumulado (Guid id, decimal percentualObjetivo)
        {
            decimal percentualAcumulado = _distribuicaoPorTipoInvestimentoRepository.GetManyBy(d => d.Id != id).Result.Sum(d => d.Valores.PercentualObjetivo);
            return percentualAcumulado + percentualObjetivo;
        }

    
    }
}
