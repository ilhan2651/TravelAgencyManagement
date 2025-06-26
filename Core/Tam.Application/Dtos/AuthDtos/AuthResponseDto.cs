namespace Tam.Application.Dtos.Auth
{
    public class AuthResponseDto
    {

        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();


    }
}
