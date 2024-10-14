using MediatR;
using Newtonsoft.Json;
using Paulino.Motorbike.Domain.Base;

namespace Paulino.Motorbike.Domain.Rental.Requests
{
    public class ReturnRentalRequest(DateTime date, int rentalId) : IRequest<BaseResponse>
    {
        public DateTime Date { get; } = date;

        [JsonIgnore]
        public int RentalId { get; } = rentalId;
    }
}
