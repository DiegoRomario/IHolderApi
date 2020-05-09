using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace IHolder.Business.Base
{
    public class Response
    {
        private readonly IList<string> _messages;
        public IEnumerable<string> Messages { get; }
        public object Data { get; }
        public bool Success { get;  }
        public Response(object result = null)
        {
            _messages = new List<string>();
            Messages = new ReadOnlyCollection<string>(_messages);
            Success = _messages.Count <= 0;
            Data = result;
        }

        public Response AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}
