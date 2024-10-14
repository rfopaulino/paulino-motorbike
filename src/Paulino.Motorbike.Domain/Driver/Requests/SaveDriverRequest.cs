using MediatR;
using Paulino.Motorbike.Domain.Base;

namespace Paulino.Motorbike.Domain.Driver.Requests
{
    public class SaveDriverRequest(string name, string cnpj, DateTime birthdate, string cnh, string cnhImage) : IRequest<BaseResponse>
    {
        public string Name { get; } = name;
        public string Cnpj { get; } = cnpj;
        public DateTime Birthdate { get; } = birthdate;
        public string CNH { get; } = cnh;
        public string CNHImage { get; } = cnhImage;
    }
}
