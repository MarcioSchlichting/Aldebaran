using Aldebaran.Accounts.Repositories;

namespace Aldebaran.Accounts.Api.Controllers;

public class AccountService
{
    private readonly IUserRepository _userRepository;

    public AccountService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<string> Login(UserLoginCommand command)
    {
        var user = await _userRepository;
        if (user == null)
        {
            throw new Exception("User not found");
        }

        if (!user.Password.Equals(command.Password))
        {
            throw new Exception("Invalid password");
        }

        return user;
    }
}