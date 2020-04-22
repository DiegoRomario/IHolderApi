﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IHolder.Business.Interfaces
{
    public interface IUser
    {
        Guid GetUserId();
        string GetUserEmail();
        string GetUserName();
        bool IsAuthenticated();
    }
}
