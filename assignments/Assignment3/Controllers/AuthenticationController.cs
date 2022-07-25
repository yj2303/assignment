using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationServices userServices;
        private string token;
        private bool isValidated;


        public AuthenticationController(AuthenticationServices userServices)
        {
            this.userServices = userServices;

        }

          //api to perform login

        [HttpPost("login")]
        public VerifyUserResponse login(LoginRequest loginRequest)
        {
            VerifyUserResponse response = new VerifyUserResponse();
            var user = new User
            {
                UserId = loginRequest.userID,
                UserName = loginRequest.username,
                Password = loginRequest.password,
            };
            response.token = userServices.VerifyUSer(loginRequest.userID, loginRequest.username, loginRequest.password);
            token = response.token;
            return response;
        }

        //api to get the details of user
        [HttpGet("userId")]
        public IEnumerable<User> Get(int userId, string token)
        {
            isValidated = userServices.ValidateToken(token, out var validatedToken, out var principal);
            
            var user = userServices.UserDetails(userId);

            return user;


        }

        //api to create the user

        [HttpPost("CreateUser")]
        public void Post(CreateUserRequest createUserRequest)
        {
            userServices.CreateUser(createUserRequest.User_name, createUserRequest.Email, createUserRequest.Password, createUserRequest.Contact_id, createUserRequest.contact);
        }


        



    }
}
