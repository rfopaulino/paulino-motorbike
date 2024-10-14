using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Driver.Requests;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class SendCNHDriverHandler : IRequestHandler<SendCNHDriverRequest, BaseResponse>
    {
        public Task<BaseResponse> Handle(SendCNHDriverRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
