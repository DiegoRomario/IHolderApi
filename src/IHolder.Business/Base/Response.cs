using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IHolder.Business.Base
{
    public class Response
    {
        private readonly IList<string> _messages;
        public IEnumerable<string> Errors { get; }
        public object Result { get; }
        public Response(object result)
        {
            _messages = new List<string>();
            Errors = new ReadOnlyCollection<string>(_messages);
            Result = result;
        }

        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}
