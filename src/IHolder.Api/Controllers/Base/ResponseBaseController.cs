using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IHolder.Business.Base;
using IHolder.Business.Interfaces;
using IHolder.Business.Interfaces.Notifications;
using IHolder.Business.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IHolder.Api.Controllers.Base
{
    [ApiController]
    public class ResponseBaseController : ControllerBase
    {
        protected readonly INotifier _notifier;
        protected readonly IMapper _mapper;
        public readonly IUser _user;
        public ResponseBaseController(INotifier notifier, IMapper mapper, IUser user)
        {
            _notifier = notifier;
            _mapper = mapper;
            _user = user;
        }

        protected ActionResult ResponseBase(Response response = null)
        {
            if (response.Success)
            {
                return Ok(response);

            }
            return BadRequest(response);

        }

        protected ActionResult ResponseBase(ModelStateDictionary modelState)
        {
            if (!ModelState.IsValid)
                NotifyModelError(modelState);
            return ResponseBase();
        }

        protected bool IsValid()
        {
            return !_notifier.HasNotification();
        }

        protected void NotifyError(string message)
        {
            _notifier.AddNotification(new Notification(message));
        }

        protected void NotifyModelError(ModelStateDictionary modelState)
        {

            IEnumerable<ModelError> errors = ModelState.Values.SelectMany(e => e.Errors);
            foreach (var item in errors)
            {
                var errorMessage = item.Exception == null ? item.ErrorMessage : item.Exception.Message;
                NotifyError(errorMessage);
            }
        }

    }
}