using FluentValidation.Results;
using MediatR;
using System;
namespace IHolder.Application.Base
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
    }
}
