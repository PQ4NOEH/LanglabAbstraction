using Langlab.Core.CORS;
using System;
using System.Collections.Generic;

namespace Langlab.Core.MOM
{
    public class ReceivedInvalidMessage: Event<ReceivedInvalidMessagePayload>
    {
        public ReceivedInvalidMessage(
            string triggeredByCommandId,
            string userId,
            DateTime createdDate,
            ReceivedInvalidMessagePayload payload):
            base(triggeredByCommandId, userId, createdDate, payload)
        { }
    }

    public class ReceivedInvalidMessagePayload
    {
        public List<string> Errors { get; private set; } = new List<string>();
        public string Message { get; private set; }

        public ReceivedInvalidMessagePayload(IEnumerable<string> errors, string message)
        {
            Errors.AddRange(errors);
            Message = message;
        }
    }
}
