using AutoMapper;
using Emlak.Api.Identity;
using Emlak.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Emlak.Api.Service
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user; 

        public AuthenticationManager(UserManager<User> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signCredentials = GetSignCredentials();
            var claims = await GetClaims();
            var tokenOptions=GenerateTokenOptions(signCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signCredentials,
            List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWtSetting");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                 expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                 signingCredentials: signCredentials);
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,_user.Email) //değişebilir user.UserName olarak
             };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;

        }

        private SigningCredentials GetSignCredentials()
        {
            var jwtSettings = _configuration.GetSection("JWtSetting");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret=new  SymmetricSecurityKey(key);
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);

        }

        public async Task<IdentityResult> RegisterUser(RegisterModel model)
        {
            var user= _mapper.Map<User>(model); 
            var result = await _userManager.CreateAsync(user,model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, model.Roles);
            }
            return result;  
        }

        public async Task<bool> ValidateUser(LoginModel model)
        {
            _user= await _userManager.FindByEmailAsync(model.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, model.Password));
            if(!result)
            {
                throw new Exception("Authentication failed .Wrong username or password");
            }
            return result;
        }
    }
}
