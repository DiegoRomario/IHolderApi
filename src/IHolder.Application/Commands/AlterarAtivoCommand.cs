using FluentValidation;
using IHolder.Application.Base;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Application.Commands
{
    public class AlterarAtivoCommand : Command<bool>
    {

        public AlterarAtivoCommand(Guid id, Guid produtoid, string descricao, string caracteristicas, string ticker, decimal cotacao)
        {
            Id = id;
            ProdutoId = produtoid;
            Ticker = ticker;
            Cotacao = cotacao;
            Descricao = descricao;
            Caracteristicas = caracteristicas;
        }

        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public string Descricao { get; set; }
        public string Caracteristicas { get; set; }
        public string Ticker { get; set; }
        public decimal Cotacao { get; set; }

    }

    public class AlterarAtivoCommandValidator : AbstractValidator<AlterarAtivoCommand>
    {
        public AlterarAtivoCommandValidator()
        {
            RuleFor(a => a.ProdutoId).NotEmpty().WithMessage("O produto deve ser informado");
            RuleFor(a => a.Ticker).NotEmpty().WithMessage("O ticker do ativo deve ser informado");
            RuleFor(a => a.Cotacao).GreaterThanOrEqualTo(0).WithMessage("O valor da cotação não pode ser negativo");
        }
    }
}
