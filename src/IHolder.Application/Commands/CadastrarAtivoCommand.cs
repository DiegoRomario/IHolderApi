using FluentValidation;
using IHolder.Application.Base;
using System;

namespace IHolder.Application.Commands
{
    public class CadastrarAtivoCommand : Command<bool>
    {

        public CadastrarAtivoCommand(Guid produtoid, string descricao, string caracteristicas, string ticker, decimal cotacao)
        {
            ProdutoId = produtoid;
            Ticker = ticker;
            Cotacao = cotacao;
            Descricao = descricao;
            Caracteristicas = caracteristicas;
        }

        public Guid ProdutoId { get; set; }
        public string Descricao { get; set; }
        public string Caracteristicas { get; set; }
        public string Ticker { get; set; }
        public decimal Cotacao { get; set; }

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
