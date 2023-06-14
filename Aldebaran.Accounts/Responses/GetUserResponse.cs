using Aldebaran.Accounts.Models;
using Aldebaran.Core.Shared.ApiResponses;

namespace Aldebaran.Accounts.Responses;

public record GetUserResponse : BaseResponse
{
    public DateTime LastLogin { get; set; }
    
    public Roles Role { get; set; }
    
    public string Name { get; set; }
    
    public string EmailAddress { get; set; }
}