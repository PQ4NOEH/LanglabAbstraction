using Langlab.Core.MOM;
using System;
using System.Collections.Generic;
using System.Text;
using Langlab.Core.CORS;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace Langlab.MOM.Conectors
{
    public class BaseMomTray : IMomTray
    {
        readonly string _trayName;
        readonly QueueClient _client;
        readonly IMomConfiguration _configuration;

        public BaseMomTray(IMomConfiguration configuration, string trayName)
        {
            _configuration = configuration;
            _client = QueueClient.CreateFromConnectionString(configuration.ConnectionString, trayName);
            _trayName = trayName;
        }
        public Task Send(IEvent @event) => Send(@event, 0);

        async Task Send(IEvent @event, int timesTried = 0)
        {
            try
            {
                var message = new BrokeredMessage(@event);
                await _client.SendAsync(message);
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException is TimeoutException && timesTried < _configuration.NumberOfRetries)
                {
                    await Task.Delay(Convert.ToInt32(_configuration.MSBetweenRetries));
                    await Send(@event, ++timesTried);
                }
                else throw ae.InnerException;

            }
        }
    }
}
