using HMS.Dto;
using HMS.Implementation.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HMS.Implementation.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string JwtWebToken(UserDto user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrEmpty(user.UserName)) throw new ArgumentNullException(nameof(user.UserName));
            if (string.IsNullOrEmpty(user.Password)) throw new ArgumentNullException(nameof(user.Password));
            if (string.IsNullOrEmpty(user.Id)) throw new ArgumentNullException(nameof(user.Id));

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               // new Claim(ClaimTypes.Email, user.Name),
                new Claim("Id", user.Id)
            };

            //create signing key
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddYears(2),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            var tokenResponse = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenResponse;
        }
    }
}
