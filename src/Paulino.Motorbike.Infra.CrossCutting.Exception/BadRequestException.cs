namespace Paulino.Motorbike.Infra.CrossCutting.Exception
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string message)
            : base (message) { }

        public BadRequestException(string message, System.Exception ex)
           : base(message, ex) { }
    }
}
