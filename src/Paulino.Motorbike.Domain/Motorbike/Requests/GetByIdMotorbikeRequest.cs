using MediatR;
using Paulino.Motorbike.Domain.Motorbike.Responses;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class GetByIdMotorbikeRequest(int id) : IRequest<GetByIdMotorbikeResponse>
    {
        public int Id { get; } = id;
    }
}
