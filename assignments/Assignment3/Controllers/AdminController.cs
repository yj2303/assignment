using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{

    //
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminServices adminServices;
        public AdminController(AdminServices adminServices)
        {
            this.adminServices = adminServices;

        }
  

        //Update the flight details
        [HttpPut("UpdateDetails")]
        public ErrorResponse UpdateDetails(int RouteID, int PlaneId)
        {

            var result = adminServices.UpdateFlightDetails(RouteID, PlaneId);
            return result;

        }

       



    }
}
