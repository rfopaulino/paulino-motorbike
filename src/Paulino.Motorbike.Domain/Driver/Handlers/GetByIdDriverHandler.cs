using MediatR;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Driver.Responses;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class GetByIdDriverHandler : IRequestHandler<GetByIdDriverRequest, GetByIdDriverResponse>
    {
        public Task<GetByIdDriverResponse> Handle(GetByIdDriverRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
