using Aldebaran.Accounts.Commands;
using Aldebaran.Domain.ApiResponses;

namespace Aldebaran.Services.Services;

public interface IAccountService
{
    public Task<ServiceResponse<UserLoginResponse>> LoginAsync(UserLoginCommand command);
    
    public Task<ServiceResponse<UserRegisterResponse>> RegisterAsync(UserRegisterCommand command);
    
    public Task<ServiceResponse<GetUserResponse>> GetUserByIdAsync(Guid id);
}
