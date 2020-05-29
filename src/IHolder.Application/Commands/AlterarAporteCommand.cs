using FluentValidation;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarAporteCommand : CadastrarAporteCommand
    {
        public AlterarAporteCommand(Guid id, Guid ativoId, decimal precoMedio, decimal quantidade, DateTime dataAporte) : base(ativoId, precoMedio, quantidade, dataAporte)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class AlterarAporteCommandValidator : AbstractValidator<AlterarAporteCommand>
    {
        public AlterarAporteCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("O Id do aporte deve ser informado");
            RuleFor(a => a.AtivoId).NotEmpty().WithMessage("O ativo deve ser informado");
            RuleFor(a => a.PrecoMedio).GreaterThan(0).WithMessage("O preço médio do aporte deve ser informado");
            RuleFor(a => a.Quantidade).GreaterThan(0).WithMessage("O quantidade de ativos do aporte deve ser informada");
        }
    }
}
