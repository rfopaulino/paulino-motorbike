using MediatR;
using Newtonsoft.Json;
using Paulino.Motorbike.Domain.Base;

namespace Paulino.Motorbike.Domain.Driver.Requests
{
    public class SendCNHDriverRequest(int driverId, string image) : IRequest<BaseResponse>
    {
        [JsonIgnore]
        public int DriverId { get; } = driverId;
        public string Image { get; } = image;
    }
}
