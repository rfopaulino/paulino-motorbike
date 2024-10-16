namespace Paulino.Motorbike.Infra.CrossCutting.EventBus
{
    public interface IEventBus
    {
        void Publish(object @event);
    }
}
