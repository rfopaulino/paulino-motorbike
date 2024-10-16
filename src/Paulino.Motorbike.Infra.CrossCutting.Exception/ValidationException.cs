namespace Paulino.Motorbike.Infra.CrossCutting.Exception
{
    public class ValidationException : System.Exception
    {
        public IEnumerable<string> Errors { get; }

        public ValidationException(IEnumerable<string> errors)
            : base("Validation Exception")
        {
            Errors = errors;
        }
    }
}
