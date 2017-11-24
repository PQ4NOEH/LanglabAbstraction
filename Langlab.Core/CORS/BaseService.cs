using Langlab.Core.MOM;
using System;
using System.Threading.Tasks;

namespace Langlab.Core.CORS
{
    public abstract class BaseService
    {
        readonly IOutputTray _outputTray;

        public BaseService(IOutputTray outputTray)
        {
            _outputTray = outputTray;
        }

        public async Task Handle(IQuery query, Func<Task<IEvent>> ProcesMessage)
        {
            IEvent @event = null;
            if (!query.IsStateValid)
            {
                var eventPayload = new ReceivedInvalidMessagePayload(query.StateErrors(), "The request is invalid");
                @event = new ReceivedInvalidMessage(query.Id, query.CreatedBy, DateTime.Now, eventPayload);
            }
            else @event = await ProcesMessage();

            if(@event != null) await _outputTray.Send(@event);
        }
    }
}
