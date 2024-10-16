using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Paulino.Motorbike.Infra.CrossCutting.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly IEventBusPersistentConnection _persistentConnection;
        private IModel _channel;

        public EventBus(IEventBusPersistentConnection persistentConnection)
        {
            _persistentConnection = persistentConnection;
            _channel = CreateChannel();
        }

        private IModel CreateChannel()
        {
            if (!_persistentConnection.IsConnected)
                _persistentConnection.TryConnect();

            var channel = _persistentConnection.CreateModel();

            DeclareExchange(channel);

            return channel;
        }

        private void DeclareExchange(IModel channel)
        {
            channel.ExchangeDeclare(
                exchange: "paulino.motorbike",
                type: "fanout");
        }

        public void Publish(object @event)
        {
            if (!_persistentConnection.IsConnected)
                _persistentConnection.TryConnect();

            using (var channel = _persistentConnection.CreateModel())
            {
                var message = JsonConvert.SerializeObject(@event);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.DeliveryMode = 2;

                channel.BasicPublish(
                    exchange: "paulino.motorbike",
                    routingKey: "",
                    mandatory: true,
                    basicProperties: properties,
                    body: body);
            }
        }
    }
}
