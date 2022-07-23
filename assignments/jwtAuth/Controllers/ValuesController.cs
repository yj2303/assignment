using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwtAuth.Controllers
{
    public class ValuesController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {


            private readonly Repository userRepository;
            public AuthController(Repository userRepository)
            {
                this.userRepository = userRepository;
            }

            [HttpGet]
            public string Get(string username, string password)
            {
                var token = userRepository.GenerateToken(username, password);

                return (string)token;
            }

            [HttpPost]
            public bool Get(string token)
            {
                bool isValid = (bool)userRepository.ValidateToken(token, out var validatedToken, out var principal);
                if (isValid)
                {
                    return true;

                }
                else
                {
                    return false;


                }

            }
        }
    }
    }



