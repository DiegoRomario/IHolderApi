using IHolder.Business.Base;
using Microsoft.AspNetCore.Mvc;

namespace IHolder.Api.Controllers.Base
{
    [ApiController]
    public class ResponseBaseController : ControllerBase
    {
        public ResponseBaseController()
        {
            _response = new Response();
        }

        public Response _response { get; private set; }
        protected ActionResult ResponseBase(Response response = null)
        {
            if (response != null)
                _response = response;

            if (_response.Result)
                return Ok(_response);

            return BadRequest(_response);
        }

        protected void NotifyError (string message)
        {
            _response.Error(message);
        }



    }
}