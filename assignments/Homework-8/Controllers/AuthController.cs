using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Homework_8.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Homework_8.Services;

namespace Homework_8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       

        private readonly Repository Repository ;
        public AuthController(Repository Repository)
        {
            this.Repository= Repository;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public string Get(string username,string password)
        {
            var token = Repository.GenerateToken(username, password);

            return (string)token;
        }

        [HttpPost]
        public bool Get(string token)
        {
            bool isValid = (bool)Repository.ValidateToken(token, out var validatedToken, out var principal);
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
