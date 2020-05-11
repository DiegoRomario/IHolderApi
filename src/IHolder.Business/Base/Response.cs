using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace IHolder.Business.Base
{
    public class Response : IResponse
    {
        private readonly List<string> _messages;
        public IEnumerable<string> Errors { get; }
        public object Data { get; private set; }
        public bool Result { get; private set; }
        public Response()
        {
            _messages = new List<string>();
            Errors = new ReadOnlyCollection<string>(_messages);
        }

        public Response Success(object result)
        {
            Data = result;
            Result = true;
            return this;
        }

        public Response Error(string message)
        {
            _messages.Add(message);
            Result = false;
            return this;
        }
        public Response Error(IEnumerable<string> messages)
        {
            _messages.AddRange(messages);
            Result = false;
            return this;
        }
    }
}
