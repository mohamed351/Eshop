using EShop.Core.Entities.Identity;
using EShop.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SymmetricSecurityKey securityKey;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
            string data = configuration["Token:Key"];
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(data));
        }
       public string  CreateToken (AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email ,user.Email),
                new Claim(ClaimTypes.GivenName,user.DisplayName)
            };
            var creditionals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescrptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials= creditionals,
                Issuer = configuration["Token:Issuer"]

            };
            var tokenHandler = new JwtSecurityTokenHandler();
          var token =  tokenHandler.CreateToken(tokenDescrptor);
            return tokenHandler.WriteToken(token);


        }
    }
}
