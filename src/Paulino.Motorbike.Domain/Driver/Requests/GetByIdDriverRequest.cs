using MediatR;
using Paulino.Motorbike.Domain.Driver.Responses;

namespace Paulino.Motorbike.Domain.Driver.Requests
{
    public class GetByIdDriverRequest(int id) : IRequest<GetByIdDriverResponse>
    {
        public int Id { get; } = id;
    }
}
