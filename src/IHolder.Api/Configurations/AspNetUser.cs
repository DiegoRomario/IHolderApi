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
            return IsAuthenticated() ?  Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) : Guid.Empty;
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
