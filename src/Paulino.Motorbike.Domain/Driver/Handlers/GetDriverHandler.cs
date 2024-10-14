using MediatR;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Driver.Responses;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class GetDriverHandler : IRequestHandler<GetDriverRequest, GetDriverResponse>
    {
        public Task<GetDriverResponse> Handle(GetDriverRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
