using FluentValidation;

namespace Paulino.Motorbike.Domain.Base
{
    public static class ExecuteValidator
    {
        public static void RunValidate<T>(this AbstractValidator<T> validator, T instance)
        {
            var result = validator?.Validate(instance);
            if (!result?.IsValid ?? true)
            {
                throw new Infra.CrossCutting.Exceptions.ValidationException(result.Errors.Select(x => x.ErrorMessage));
            }
        }
    }
}
