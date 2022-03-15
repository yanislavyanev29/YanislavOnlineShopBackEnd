using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace YanislavOnlineShopBackEnd.Utilities
{
    public static class JwtGenerator
    {

        public static string GenerateAuthToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,username)
            };

            return GenerateAuthToken(claims, DateTime.UtcNow.AddDays(1));
        }

        private static string GenerateAuthToken(Claim[] claims, DateTime expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                Issuer = issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
