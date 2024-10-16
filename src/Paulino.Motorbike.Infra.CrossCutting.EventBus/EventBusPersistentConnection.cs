using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Paulino.Motorbike.Infra.CrossCutting.EventBus
{
    public class EventBusPersistentConnection : IEventBusPersistentConnection, IDisposable
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private bool _disposed;

        public EventBusPersistentConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool IsConnected =>
            _connection != null && _connection.IsOpen && !_disposed;

        public bool TryConnect()
        {
            _connection = _connectionFactory.CreateConnection();

            if (!IsConnected)
                return false;

            _connection.ConnectionShutdown += OnConnectionShutdown;
            _connection.CallbackException += OnCallbackException;
            _connection.ConnectionBlocked += OnConnectionBlocked;

            return true;
        }

        public IModel CreateModel()
        {
            if (!IsConnected)
                throw new InvalidOperationException();

            return _connection.CreateModel();
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;
            _connection.Dispose();
        }

        private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            if (_disposed)
                return;

            TryConnect();
        }

        private void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            if (_disposed)
                return;

            TryConnect();
        }

        private void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            if (_disposed)
                return;

            TryConnect();
        }
    }
}
