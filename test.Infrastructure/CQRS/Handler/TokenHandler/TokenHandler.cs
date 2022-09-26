using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using test.Entity.Entities;
using test.Infrastructure.Dtos.JwtDto;

namespace test.Infrastructure.CQRS.Handler.TokenHandler
{

    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenDto CreateAccessToken(Login login)
        {
            TokenDto token = new();
            //Security key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Oluşturulacak Token ayarlarını veriyoruz.
            token.Expiration = DateTime.UtcNow.AddMinutes(30);


            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );


            //Token oluşturucu
            JwtSecurityTokenHandler tokenhandler = new();
            token.AccessToken = tokenhandler.WriteToken(securityToken);



            return token;
        }

        private string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            };
        }
    }
}
