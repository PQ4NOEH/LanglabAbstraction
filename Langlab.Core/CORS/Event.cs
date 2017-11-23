using System;

namespace Langlab.Core.CORS
{
    public interface IEvent<T>
    {
        string TriggeredByCommandId { get; }
        DateTime CreatedDate { get; }
        T Payload { get; }
    }

    public abstract class Event<T>: IEvent<T>
    {
        public string TriggeredByCommandId { get; }
        public DateTime CreatedDate { get;  }
        public T Payload { get;  }
        public Event(string triggeredByCommandId, DateTime createdDate, T payload)
        {
            if (string.IsNullOrWhiteSpace(triggeredByCommandId)) throw new ArgumentNullException("triggeredByCommandId");
            if (payload == null) throw new ArgumentNullException("payload");
            TriggeredByCommandId = triggeredByCommandId;
            CreatedDate = createdDate;
            Payload = payload;
        }
    }
}
