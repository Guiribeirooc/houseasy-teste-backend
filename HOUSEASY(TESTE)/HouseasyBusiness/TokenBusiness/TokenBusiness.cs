using HouseasyModel.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HouseasyBusiness.TokenBusiness
{
    public class TokenBusiness : ITokenBusiness
    {
        private readonly string _secret;
        public TokenBusiness()
        {
            _secret = Environment.GetEnvironmentVariable("JWT_SECRETO");
        }
        public async Task<LoginResponse> GerarToken(LoginResponse loginResponse)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(_secret);

            var claimsIdendity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, loginResponse.User)
            });

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdendity,
                Issuer = "EmitenteDoJWT",
                Audience = "DestinatarioDoJWT",
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            loginResponse.Authenticated = true;
            loginResponse.ExpirationDate = tokenDescriptor.Expires;
            loginResponse.Token = tokenHandler.WriteToken(token);

            return loginResponse;
        }
    }
}
