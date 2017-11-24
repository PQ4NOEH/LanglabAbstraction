using System;

namespace Langlab.Core.CORS
{
    public interface IEvent
    {
        string TriggeredByCommandId { get; }
        string UserId { get; }
        DateTime CreatedDate { get; }
    }
    public interface IEvent<T>: IEvent
    {
        T Payload { get; }
    }

    public abstract class Event<T>: IEvent<T>
    {
        public string TriggeredByCommandId { get; }
        public string UserId { get; }
        public DateTime CreatedDate { get;  }
        public T Payload { get;  }
        public Event(string triggeredByCommandId, string userId, DateTime createdDate, T payload)
        {
            if (string.IsNullOrWhiteSpace(triggeredByCommandId)) throw new ArgumentNullException("triggeredByCommandId");
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentNullException("userId");
            if (payload == null) throw new ArgumentNullException("payload");
            UserId = userId;
            TriggeredByCommandId = triggeredByCommandId;
            CreatedDate = createdDate;
            Payload = payload;
        }
    }
}
