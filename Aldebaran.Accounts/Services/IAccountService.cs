using Aldebaran.Accounts.Commands;
using Aldebaran.Domain.ApiResponses;

namespace Aldebaran.Accounts.Services;

public interface IAccountService
{
    public Task<ServiceResponse<UserLoginResponse>> LoginAsync(UserLoginCommand command);
}
