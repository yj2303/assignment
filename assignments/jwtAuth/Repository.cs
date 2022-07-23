
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Security.Principal;

namespace jwtAuth
{
    public class Repository
    {
        private static readonly List<UserModels> users;
        const string ISSUER = "issuing-website-url";
        const string AUDIENCE = "target-website-url";
        const string key = "46a6fa5340b1a87b988e4e4326900c8bebf8668648579e91441d1158daf48eb60ad8d035492f8cc8846624eed68c2ee34e08db774af2bd94fb7b9";

        private static readonly SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));



        private static string generatedToken = null;


        static Repository()
        {
            users = new List<UserModels>()
            {
                new UserModels{Name = "Yashika" , Password ="Passw0rd"},
                new UserModels{Name = "Mahima" , Password ="Passw0rd1"}


            };

        }

        internal object GenerateToken(string username, string password)
        {
            try {
                var LoginDetails = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var secToken = new JwtSecurityToken(
                    signingCredentials: LoginDetails,
                    issuer: ISSUER,
                    audience: AUDIENCE,
                    claims: new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, username),
                    new Claim(JwtRegisteredClaimNames.UniqueName, password)
                    }

                );

                var handler = new JwtSecurityTokenHandler();

                generatedToken = handler.WriteToken(secToken);
                return handler.WriteToken(secToken);
            }
            catch{
                 throw new NotImplementedException();
            }

            }
       


        internal object ValidateToken(string generatedToken, out SecurityToken? validatedToken, out IPrincipal? principal)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = ISSUER,
                ValidAudience = AUDIENCE,
                IssuerSigningKey = securityKey
            };
                principal = tokenHandler.ValidateToken(generatedToken, validationParameters, out validatedToken);

                return true;
            
        }









    }
}