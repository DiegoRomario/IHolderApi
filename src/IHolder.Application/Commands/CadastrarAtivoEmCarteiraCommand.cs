using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarAtivoEmCarteiraCommand : Command<bool>
    {
        public CadastrarAtivoEmCarteiraCommand(Guid ativoId, decimal precoMedio, decimal quantidade, DateTime dataPrimeiroAporte)
        {
            AtivoId = ativoId;
            PrecoMedio = precoMedio;
            Quantidade = quantidade;
            DataPrimeiroAporte = dataPrimeiroAporte == DateTime.MinValue ? DateTime.Now : dataPrimeiroAporte;
        }

        public Guid AtivoId { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataPrimeiroAporte { get; set; }

    }

    public class CadastrarAtivoEmCarteiraCommandValidator : AbstractValidator<CadastrarAtivoEmCarteiraCommand>
    {
        public CadastrarAtivoEmCarteiraCommandValidator()
        {
            RuleFor(a => a.AtivoId).NotEmpty().WithMessage("O ativo deve ser informado");
            RuleFor(a => a.PrecoMedio).GreaterThan(0).WithMessage("O preço médio do ativo deve ser informado");
            RuleFor(a => a.Quantidade).GreaterThan(0).WithMessage("O quantidade de ativos deve ser informada");
        }
    }
}
