
namespace WSH_HomeAssignment.Api.Contracts.Authentication.Outputs
{
    public class TokenDto
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public DateTime Expiration { get; set; }
        public string Value { get; set; } = null!;
    }
}