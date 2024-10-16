using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Infra.CrossCutting.EventBus;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Paulino.Motorbike.Domain.Consumers
{
    public class NewMotorbike2024Consumer : IConsumer
    {
        private readonly IEventBusPersistentConnection _persistentConnection;
        private readonly IServiceScopeFactory _scopeFactory;
        private IModel _consumerChannel;
        private readonly string _queue;

        public NewMotorbike2024Consumer(string queue, IEventBusPersistentConnection persistentConnection, IServiceScopeFactory scopeFactory)
        {
            _queue = queue;
            _persistentConnection = persistentConnection;
            _scopeFactory = scopeFactory;
        }

        public void Subscribe()
        {
            if (!_persistentConnection.IsConnected)
                _persistentConnection.TryConnect();

            var channel = _persistentConnection.CreateModel();

            DeclareQueue(channel);
            BindQueue(channel);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var motorbike = JsonConvert.DeserializeObject<Infra.Data.EF.Entities.Motorbike>(message);

                if (motorbike.Year == 2024)
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                        await mediator.Send(new AddMotorbike2024Request(message));
                    }
                }
            };

            channel.BasicQos(0, 25, false);
            channel.BasicConsume(queue: _queue,
                                 autoAck: true,
                                 consumer: consumer);
        }

        private void DeclareQueue(IModel channel)
        {
            channel.QueueDeclare(
                queue: _queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        private void BindQueue(IModel channel)
        {
            channel.QueueBind(queue: _queue,
                              exchange: "paulino.motorbike",
                              routingKey: "");
        }
    }
}
