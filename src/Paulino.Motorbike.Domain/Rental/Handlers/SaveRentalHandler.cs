using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Rental.Requests;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class SaveRentalHandler : IRequestHandler<SaveRentalRequest, BaseResponse>
    {
        public Task<BaseResponse> Handle(SaveRentalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
