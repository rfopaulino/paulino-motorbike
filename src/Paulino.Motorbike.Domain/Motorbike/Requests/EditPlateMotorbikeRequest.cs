using MediatR;
using Newtonsoft.Json;
using Paulino.Motorbike.Domain.Base;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class EditPlateMotorbikeRequest(string plate, int motorbikeId) : IRequest<BaseResponse>
    {
        public string Plate { get; } = plate;

        [JsonIgnore]
        public int MotorbikeId { get; } = motorbikeId;
    }
}
