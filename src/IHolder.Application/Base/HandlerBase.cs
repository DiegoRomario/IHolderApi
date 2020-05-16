using MediatR;

namespace IHolder.Application.Base
{
    public class HandlerBase : IHandlerBase
    {
        private readonly IMediator _mediator;
        public HandlerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        public bool ValidateCommand<T>(Command<T> command)
        {
            if (command.IsValid())
                return true;

            foreach (var item in command.ValidationResult?.Errors)
            {
                PublishNotification(item.ErrorMessage);
            }
            return false;
        }

        public void PublishNotification(string message)
        {
            _mediator.Publish(new Notification(message));
        }

    }
}
