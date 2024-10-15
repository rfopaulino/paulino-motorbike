using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Infra.CrossCutting.Regex;
using System.Text.Json.Serialization;

namespace Paulino.Motorbike.Domain.Driver.Requests
{
    public class SaveDriverRequest(string name, string cnpj, DateTime birthdate, string cnh, int cnhTypeId) : IRequest<BaseResponse>
    {
        public string Name { get; } = name;
        public string CNPJ { get; } = cnpj;
        public DateTime Birthdate { get; } = birthdate;
        public string CNH { get; } = cnh;
        public int CNHTypeId { get; } = cnhTypeId;

        [JsonIgnore]
        public string CNPJUnformatted => OnlyNumberRegex.Apply(CNPJ);
    }
}
