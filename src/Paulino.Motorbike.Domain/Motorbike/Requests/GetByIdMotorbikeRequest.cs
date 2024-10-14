using MediatR;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class GetByIdMotorbikeRequest(int id) : IRequest<GetByIdMotorbikeRequest>
    {
        public int Id { get; } = id;
    }
}
