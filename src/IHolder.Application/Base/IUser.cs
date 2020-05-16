using System;

namespace IHolder.Application.Base
{
    public interface IUser
    {
        Guid GetUserId();
        string GetUserEmail();
        string GetUserName();
        bool IsAuthenticated();
    }
}
