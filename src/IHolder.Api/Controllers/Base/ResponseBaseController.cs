using IHolder.Application.Base;
using Microsoft.AspNetCore.Mvc;

namespace IHolder.Api.Controllers.Base
{
    [ApiController]
    public class ResponseBaseController : ControllerBase
    {
        protected ActionResult ResponseBase(Response response)
        {
            if (response.Result)
                return Ok(response);

            return BadRequest(response);
        }
    }
}