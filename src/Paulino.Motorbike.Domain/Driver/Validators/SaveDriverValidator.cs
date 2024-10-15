using DocumentValidator;
using FluentValidation;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Domain.Enums;

namespace Paulino.Motorbike.Domain.Driver.Validators
{
    public class SaveDriverValidator : AbstractValidator<SaveDriverRequest>
    {
        public SaveDriverValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CNPJ).NotEmpty();
            RuleFor(x => x.CNPJ).Must(CnpjValidation.Validate).When(x => x.CNPJ != null);
            RuleFor(x => x.Birthdate).NotEmpty();
            RuleFor(x => x.CNH).NotEmpty();
            RuleFor(x => x.CNH).Must(CnhValidation.Validate).When(x => x.CNH != null);
            RuleFor(x => x.CNHTypeId).Must(CNHTypeValidation);
        }

        private bool CNHTypeValidation(int cnhTypeId)
        {
            return cnhTypeId == (int)CNHTypeEnum.A || cnhTypeId == (int)CNHTypeEnum.B || cnhTypeId == (int)CNHTypeEnum.AB;
        }
    }
}
