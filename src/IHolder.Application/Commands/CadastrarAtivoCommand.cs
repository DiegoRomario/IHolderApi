using FluentValidation;
using IHolder.Application.Base;
using IHolder.Domain.ValueObjects;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarAtivoCommand : Command<bool>
    {

        public CadastrarAtivoCommand(Guid produtoid, string descricao, string caracteristicas, string ticker, decimal cotacao, Guid usuarioId)
        {
            ProdutoId = produtoid;
            Ticker = ticker;
            Cotacao = cotacao;
            UsuarioId = usuarioId;
            Informacoes = new Informacoes(descricao, caracteristicas);
        }

        public Guid ProdutoId { get; private set; }
        public Informacoes Informacoes { get; set; }
        public string Ticker { get; private set; }
        public decimal Cotacao { get; private set; }
        public Guid UsuarioId { get; set; }

    }

    public class CadastrarAtivoCommandValidator : AbstractValidator<CadastrarAtivoCommand>
    {
        public CadastrarAtivoCommandValidator()
        {
            RuleFor(a => a.ProdutoId).NotEmpty().WithMessage("O produto deve ser informado");
            RuleFor(a => a.Ticker).NotEmpty().WithMessage("O ticker do ativo deve ser informado");
            RuleFor(a => a.Cotacao).GreaterThanOrEqualTo(0).WithMessage("O valor da cotação não pode ser negativo");            
        }
    }
}
