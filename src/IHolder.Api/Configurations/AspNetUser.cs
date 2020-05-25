using IHolder.Domain.DomainObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace IHolder.Api.Configurations
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value : string.Empty;
        }

        public Guid GetUserId()
        {
#if DEBUG 
            return new Guid("EC1C63CE-5733-47B5-860C-23D7E62660E7");
#else
            return IsAuthenticated() ?  Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) : Guid.Empty;
#endif
        }

        public string GetUserName()
        {
            return IsAuthenticated() ? _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value : string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
