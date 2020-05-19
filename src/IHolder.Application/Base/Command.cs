using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
namespace IHolder.Application.Base
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        [JsonIgnore]
        public ValidationResult ValidationResult { get;  set; }
        public abstract bool IsValid();


    }
}
