using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SalesOnline.Application.Models;
using SalesOnline.Infraestructure.Models.Usuario;


namespace SalesOnline.Auth.Api.Core
{
    public static class TokenHelper
    {
        public static TokenInfo GetToken(UsuarioModel usuario, string siginigKey) 
        {
            TokenInfo tokenInfo = new TokenInfo();

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(siginigKey);


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] 
                {
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Correo),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }), 
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            tokenInfo.FechaExpiracion = tokenDescriptor.Expires;
            tokenInfo.Token = tokenHandler.WriteToken(token);

            return tokenInfo;
        }
    }
}
