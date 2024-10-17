namespace Paulino.Motorbike.Api.Identity
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public string Type { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
