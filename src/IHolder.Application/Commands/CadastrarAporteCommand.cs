using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarAporteCommand : Command<bool>
    {
        public CadastrarAporteCommand(Guid ativoId, decimal precoMedio, decimal quantidade, DateTime dataAporte)
        {
            AtivoId = ativoId;
            PrecoMedio = precoMedio;
            Quantidade = quantidade;
            DataAporte = dataAporte == DateTime.MinValue ? DateTime.Now : dataAporte;
        }

        public Guid AtivoId { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataAporte { get; set; }

    }

    public class CadastrarAporteCommandValidator : AbstractValidator<CadastrarAporteCommand>
    {
        public CadastrarAporteCommandValidator()
        {
            RuleFor(a => a.AtivoId).NotEmpty().WithMessage("O ativo deve ser informado");
            RuleFor(a => a.PrecoMedio).GreaterThan(0).WithMessage("O preço médio do aporte deve ser informado");
            RuleFor(a => a.Quantidade).GreaterThan(0).WithMessage("O quantidade de ativos do aporte deve ser informada");
        }
    }
}
