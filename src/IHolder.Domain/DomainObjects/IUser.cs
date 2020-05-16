using System;

namespace IHolder.Domain.DomainObjects
{
    public interface IUser
    {
        Guid GetUserId();
        string GetUserEmail();
        string GetUserName();
        bool IsAuthenticated();
    }
}
