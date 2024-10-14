using MediatR;
using Newtonsoft.Json;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class DeleteByIdMotorbikeRequest(int id) : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; } = id;
    }
}
