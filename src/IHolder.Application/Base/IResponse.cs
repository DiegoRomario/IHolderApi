using System.Collections.Generic;

namespace IHolder.Application.Base
{
    public interface IResponse
    {
        IEnumerable<string> Errors { get; }
        object Data { get; }
        bool Result { get; }

        Response Success(object data);
        Response Error(string message);
        Response Error(IEnumerable<string> messages);
    }
}