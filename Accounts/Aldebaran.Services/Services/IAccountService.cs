using Aldebaran.Accounts.Commands;
using Aldebaran.Domain.ApiResponses;

namespace Aldebaran.Services.Services;

public interface IAccountService
{
    public Task<ServiceResponse<UserLoginResponse>> LoginAsync(UserLoginCommand command);
}
