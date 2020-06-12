using FluentValidation;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarAtivoEmCarteiraCommand : CadastrarAtivoEmCarteiraCommand
    {
        public AlterarAtivoEmCarteiraCommand(Guid id, Guid ativoId, decimal precoMedio, decimal quantidade, DateTime dataPrimeiroAporte) : base(ativoId, precoMedio, quantidade, dataPrimeiroAporte)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }

    public class AlterarAtivoEmCarteiraCommandValidator : AbstractValidator<AlterarAtivoEmCarteiraCommand>
    {
        public AlterarAtivoEmCarteiraCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("O Id do ativo em carteira deve ser informado");
            RuleFor(a => a.AtivoId).NotEmpty().WithMessage("O ativo deve ser informado");
            RuleFor(a => a.PrecoMedio).GreaterThan(0).WithMessage("O preço médio do ativo deve ser informado");
            RuleFor(a => a.Quantidade).GreaterThan(0).WithMessage("O quantidade de ativos deve ser informada");
        }
    }
}
