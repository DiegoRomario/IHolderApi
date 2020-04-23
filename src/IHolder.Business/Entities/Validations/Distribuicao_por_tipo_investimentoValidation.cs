using FluentValidation;
using IHolder.Business.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IHolder.Business.Entities.Validations
{
    public class Distribuicao_por_tipo_investimentoValidation : AbstractValidator<Distribuicao_por_tipo_investimento>
    {
        private readonly IDistribuicao_por_tipo_investimentoRepository _distribuicao_Por_Tipo_InvestimentoRepository;
        public Distribuicao_por_tipo_investimentoValidation(IDistribuicao_por_tipo_investimentoRepository distribuicao_Por_Tipo_InvestimentoRepository)
        {
            _distribuicao_Por_Tipo_InvestimentoRepository = distribuicao_Por_Tipo_InvestimentoRepository;
            RuleFor(d => d.Percentual_objetivo).InclusiveBetween(1, 100).WithMessage("O Percentual objetivo deve estar entre {From} e {To}.");
            RuleFor(d => d).Must(d => PercentualObjetivoAcumulado(d.Id, d.Percentual_objetivo) <= 100).WithMessage("O Percentual objetivo informado somado ao percentual objetivo acumulado ultrapassa 100%");
        }

        protected decimal PercentualObjetivoAcumulado (Guid id, decimal percentual_objetivo)
        {
            decimal percentualAcumulado = _distribuicao_Por_Tipo_InvestimentoRepository.GetManyBy(d => d.Id != id).Result.Sum(d => d.Percentual_objetivo);
            return percentualAcumulado + percentual_objetivo;
        }

    
    }
}
