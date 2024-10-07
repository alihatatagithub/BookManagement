using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.Helpers
{
    public class SecurityHelper
    {
        private readonly IConfiguration _configuration;
        public SecurityHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Claim[] GenerateClaims(string userId,string email)

        {
            Claim[] claims = new[]
            {

                new Claim("UserId", userId),
                new Claim(ClaimTypes.Email, email),
                //new Claim("RoleId",RoleId.ToString()),
                //new Claim(ClaimTypes.Role,RoleId.ToString())

            };
            return claims;
        }
        public string ValidateAccessToken(string accessToken)
        {
            string userId = string.Empty;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["SigningKey"].ToString());
                tokenHandler.ValidateToken(accessToken, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                userId = jwtToken.Claims.First(x => x.Type == "UserId").Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return userId;
        }
        public string GenerateToken(string userId,string email)
        {
            Claim[] claims = new[]
            {

                new Claim(ClaimTypes.Email, email),
                new Claim("UserId", userId),
                //new Claim("RoleId",RoleId.ToString()),
                //new Claim(ClaimTypes.Role,RoleId.ToString())

            };

            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer: _configuration["Issuer"],
                audience: _configuration["Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_configuration["DurationMinuates"])),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SigningKey"])), SecurityAlgorithms.HmacSha256)
            );
            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenStr;
        }
        public string GetUserIdFromToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken principal = tokenHandler.ReadJwtToken(token);
            return principal.Claims.Where(a => a.Type == "UserId").Select(c => c.Value).First();
        }
        public string GenerateRefreshToken()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);

        }

    }

}
