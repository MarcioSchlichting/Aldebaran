using Aldebaran.Core.Shared.ApiResponses;

namespace Aldebaran.Accounts.Responses;

public record UserLoginResponse : BaseResponse
{
    public string Token { get; set; }
}
