using IHolder.Application.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace IHolder.Api.Controllers.Base
{
    [ApiController]
    public abstract class ResponseBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        private readonly NotificationHandler _notifications;

        protected ResponseBaseController(IMediator mediator,
            INotificationHandler<Notification> notifications)
        {
            _mediator = mediator;
            _notifications = (NotificationHandler)notifications;
        }

        protected bool IsValidOperation()
        {
            return !_notifications.HasNotification();
        }

        protected IEnumerable<string> GetErrorMessages()
        {
            return _notifications.GetNotifications().Select(c => c.Message).ToList();
        }

        protected void NotifyError(string error)
        {
            _mediator.Publish(new Notification(error));
        }

        protected ActionResult ResponseBase (object result = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    result = true,
                    data = result
                });
            }
            return BadRequest(new
            {
                result = false,
                errors = GetErrorMessages()
            });
        }

    }
}