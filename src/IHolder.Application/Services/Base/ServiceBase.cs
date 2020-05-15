using FluentValidation;
using FluentValidation.Results;
using IHolder.Domain.DomainObjects;
using IHolder.Application.Interfaces.Notifications;
using IHolder.Application.Notifications;


namespace IHolder.Application.Services.Base
{
    public abstract class ServiceBase
    {
        private readonly INotifier _notifier;

        protected ServiceBase(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify (Notification message)
        {
            _notifier.AddNotification(message);
        }

        protected void Notify (ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notify(new Notification(erro.ErrorMessage));
            }
        }

        protected bool RunValidation<TValidation, TEntity>(TValidation validation, TEntity entity) 
                                    where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            ValidationResult validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;

        }

    }
}
