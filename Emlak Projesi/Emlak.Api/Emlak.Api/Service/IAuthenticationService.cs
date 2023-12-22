using Emlak.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Emlak.Api.Service
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(RegisterModel model);
        Task<bool>ValidateUser(LoginModel model);
        Task<string> CreateToken();

    }
}
