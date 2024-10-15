using MediatR;
using Paulino.Motorbike.Domain.Driver.Responses;

namespace Paulino.Motorbike.Domain.Driver.Requests
{
    public class GetDriverRequest(string? cnh, string? cnpj) : IRequest<List<GetDriverResponse>>
    {
        public string? CNH { get; } = cnh;
        public string? CNPJ { get; } = cnpj;
    }
}
