using FluentValidation.Results;
using MediatR;

namespace IHolder.Application.Base
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
