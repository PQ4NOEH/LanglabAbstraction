using Langlab.Core.CORS;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Langlab.Core.MessageRouter
{
    public class CommandRouter
    {
        readonly static Dictionary <string, QueueClient> _client = new Dictionary<string, QueueClient>();
        readonly static NamespaceManager _namespaceManager = NamespaceManager.Create();
        public Task RouteCommand(ICommand command) => SendMessage(command);
        public Task RouteQuery(IQuery query) => SendMessage(query);
       
        public async Task SendMessage(object messsage)
        {
            var queueName = messsage.GetType().FullName.ToLower();
            if (!_client.ContainsKey(queueName)) _client.Add(queueName, QueueClient.Create(queueName));
            var client = _client[queueName];
            await client.SendAsync(new BrokeredMessage(messsage));
        }

        async Task<QueueClient> CreateClient(string queueName)
        {
            if (await _namespaceManager.QueueExistsAsync(queueName)) return QueueClient.Create(queueName);
            else throw new QueueNameDoesNotExistException(queueName);

        }
    }

    public class QueueNameDoesNotExistException:Exception
    {
        public string QueueName { get; }
        public QueueNameDoesNotExistException(string queueName)
        {
            QueueName = queueName;
        }
    }
}
