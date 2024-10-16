using RabbitMQ.Client;

namespace Paulino.Motorbike.Infra.CrossCutting.EventBus
{
    public interface IEventBusPersistentConnection
    {
        bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
