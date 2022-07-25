using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly OperatorServices operatorServices;
        public OperatorController(OperatorServices operatorServices)
        {
            this.operatorServices = operatorServices;

        }

        // Add new Instances to a route

      

        public class AddNewInstances
        {
          

            public string Name { get; set; }
            public int Eseats { get; set; }
            public int Bseats { get; set; }

            public int Fseats { get; set; }
            public int RouteId { get; set; }

        }
        [HttpPost("AddNewInstances")]
        public ErrorResponse  Post(AddNewInstances addInstanceRequest)
        {
            var result= operatorServices.addNewInstancesToRoutes(addInstanceRequest.Name, addInstanceRequest.Eseats, addInstanceRequest.Bseats, addInstanceRequest.Fseats, addInstanceRequest.RouteId);
            return result;
        }

      

    }
}
