﻿using FluentValidation;
using IHolder.Business.Interfaces.Repositories;
using System;
namespace IHolder.Domain.Entities.Validations
{
    public class TipoInvestimentoValidation : AbstractValidator<TipoInvestimento>
    {
        private readonly ITipoInvestimentoRepository _tipoInvestimentoRepository;

        public TipoInvestimentoValidation(ITipoInvestimentoRepository tipoInvestimentoRepository)
        {
            this._tipoInvestimentoRepository = tipoInvestimentoRepository;
            RuleFor(t => t).Must(t => DescricaoExistente(t.Id, t.Informacoes.Descricao)).WithMessage("Já existe um registro cadastrado com a mesma descrição.");
        }

        protected bool DescricaoExistente(Guid id, string descricao)
        {
            TipoInvestimento response = _tipoInvestimentoRepository.GetBy(t => t.Informacoes.Descricao == descricao && t.Id != id).Result;
            return response == null;
        }
    }
}
