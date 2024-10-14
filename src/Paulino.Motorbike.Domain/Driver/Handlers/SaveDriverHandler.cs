using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Driver.Requests;

namespace Paulino.Motorbike.Domain.Driver.Handlers
{
    public class SaveDriverHandler : IRequestHandler<SaveDriverRequest, BaseResponse>
    {
        public Task<BaseResponse> Handle(SaveDriverRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
