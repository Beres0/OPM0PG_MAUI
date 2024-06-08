using WSH_HomeAssignment.Api.Contracts.Authentication.Outputs;
using WSH_HomeAssignment.Domain.Authentication;

namespace WSH_HomeAssignment.Api.Services.Authentication.Outputs
{
    public static class TokenDtoMapper
    {
        public static TokenDto ToDto(this Token token)
        {
            return new TokenDto()
            {
                UserId = token.UserId,
                UserName = token.UserName,
                Expiration = token.Expiration,
                Value = token.Value,
            };
        }
    }
}