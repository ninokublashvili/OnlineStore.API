namespace OnlineStore.Application.Services.JWTService.Models
{
    public class JWTModel
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
