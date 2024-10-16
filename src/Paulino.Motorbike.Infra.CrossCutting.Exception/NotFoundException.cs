namespace Paulino.Motorbike.Infra.CrossCutting.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string message, System.Exception ex)
           : base(message, ex) { }
    }
}
