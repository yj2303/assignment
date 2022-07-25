using Assignment3.Models;
using Assignment3.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerServices passengerServices;

        public PassengerController(PassengerServices passengerServices)
        {
            this.passengerServices = passengerServices;
        }

        //api to view ticket details
        [HttpGet("Ticket")]
        public PassengerResponse GetTicket(int passengerId)
        {
            var result = passengerServices.ViewTicket(passengerId);
            return result;
        }

        public class BookTicket
        { public int userId { get; set; }

            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public int contactId { get; set; }

            public int phone { get; set; }
            public string type { get; set; }
            public int flightinstID { get; set; }
            public int age { get; set; }

            public string sex { get; set; }



        }

        //api to book a ticket
        [HttpPost("TicketBooking")]
        public ErrorResponse TicketBooking(BookTicket bookTicket)
        {
            var result = passengerServices.BookATicket(bookTicket.userId, bookTicket.username, bookTicket.email, bookTicket.password, bookTicket.contactId, bookTicket.phone, bookTicket.type, bookTicket.flightinstID, bookTicket.age, bookTicket.sex);
            return result;
        }
        //C:\Users\Admin\Documents\GitHub\assignment\assignments\Assignment3\Assignment3.csproj

    }
}
