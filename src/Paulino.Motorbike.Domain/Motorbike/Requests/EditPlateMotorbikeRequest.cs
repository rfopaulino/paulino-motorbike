using MediatR;
using Newtonsoft.Json;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Infra.CrossCutting.Regex;

namespace Paulino.Motorbike.Domain.Motorbike.Requests
{
    public class EditPlateMotorbikeRequest(string plate, int motorbikeId) : IRequest<BaseResponse>
    {
        public string Plate { get; } = plate;

        [JsonIgnore]
        public int MotorbikeId { get; } = motorbikeId;

        [JsonIgnore]
        public string PlateUnformatted => LetterAndNumberRegex.Apply(Plate)?.ToUpper();
    }
}
