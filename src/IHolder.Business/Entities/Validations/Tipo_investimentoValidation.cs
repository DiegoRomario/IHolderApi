using FluentValidation;
using IHolder.Business.Interfaces.Repositories;
using System;
namespace IHolder.Business.Entities.Validations
{
    public class Tipo_investimentoValidation : AbstractValidator<Tipo_investimento>
    {
        private readonly ITipo_investimentoRepository _tipo_InvestimentoRepository;

        public Tipo_investimentoValidation(ITipo_investimentoRepository tipo_InvestimentoRepository)
        {
            this._tipo_InvestimentoRepository = tipo_InvestimentoRepository;
            RuleFor(t => t).Must(t => DescricaoExistente(t.Id, t.Descricao)).WithMessage("Já existe um registro cadastrado com a mesma descrição.");
        }

        protected bool DescricaoExistente(Guid id, string descricao)
        {
            Tipo_investimento response = _tipo_InvestimentoRepository.GetBy(t => t.Descricao == descricao && t.Id != id).Result;
            return response == null;
        }
    }
}
