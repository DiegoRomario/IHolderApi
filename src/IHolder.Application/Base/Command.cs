using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
using System;

namespace IHolder.Application.Base
{
    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        [JsonIgnore]
        public Guid UsuarioId { get; set; }
        //public ValidationResult ValidationResult { get;  set; }
        //public abstract bool IsValid();
    }
}
