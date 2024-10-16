using MediatR;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class AddMotorbike2024Request(string message) : IRequest<Unit>
    {
        public string Message { get; } = message;
    }
}
