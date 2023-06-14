using Aldebaran.Core.Shared.ApiResponses;

namespace Aldebaran.Accounts.Responses;

public record UserRegisterResponse : BaseResponse
{
    public Guid Id { get; set; }
}
