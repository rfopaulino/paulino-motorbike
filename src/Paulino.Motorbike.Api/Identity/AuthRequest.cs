namespace Paulino.Motorbike.Api.Identity
{
    public class AuthRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
