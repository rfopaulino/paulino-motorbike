using FluentValidation;
using Paulino.Motorbike.Domain.Driver.Requests;
using Paulino.Motorbike.Infra.CrossCutting.Image;

namespace Paulino.Motorbike.Domain.Driver.Validators
{
    public class SendCNHDriverValidator : AbstractValidator<SendCNHDriverRequest>
    {
        public SendCNHDriverValidator()
        {
            RuleFor(x => x.DriverId).NotEmpty();
            RuleFor(x => x.DriverId).GreaterThan(0);
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.Image).Must(ImageValidation.Validate).When(x => x.Image != null);
            RuleFor(x => x.Image).Must(ImageExtensionValidation.Validate).When(x => x.Image != null);
        }
    }
}
