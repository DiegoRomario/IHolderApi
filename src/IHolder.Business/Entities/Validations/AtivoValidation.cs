using FluentValidation;
namespace IHolder.Domain.Entities.Validations
{
    public class AtivoValidation : AbstractValidator<Ativo>
    {
        public AtivoValidation()
        {
            RuleFor(f => f.Cotacao)
                .GreaterThan(0).WithMessage("O valor da cotação precisa ser maior do que {ComparisonValue}");
        }
    }
}
