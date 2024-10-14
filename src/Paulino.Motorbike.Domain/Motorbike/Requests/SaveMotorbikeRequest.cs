using MediatR;
using Paulino.Motorbike.Domain.Base;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class SaveMotorbikeRequest(int Year, string Model, string Plate) : IRequest<BaseResponse>
    {
        public int Year { get; } = Year;
        public string Model { get; } = Model;
        public string Plate { get; } = Plate;
    }
}
