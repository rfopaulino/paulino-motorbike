using MediatR;
using Paulino.Motorbike.Domain.Motorbike.Responses;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class GetMotorbikeRequest(int? year, string? model, string? plate) : IRequest<List<GetMotorbikeResponse>>
    {
        public int? Year { get; } = year;
        public string? Model { get; } = model;
        public string? Plate { get; } = plate;
    }
}
