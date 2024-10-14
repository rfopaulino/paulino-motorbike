using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Rental.Requests;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class ReturnRentalHandler : IRequestHandler<ReturnRentalRequest, BaseResponse>
    {
        public Task<BaseResponse> Handle(ReturnRentalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
