//using assignment_3.Models;
using Assignment3.Models;

namespace Assignment3.services
{
    public class PassengerServices
    {
        private readonly flightbookingContext dbContext;
        public PassengerServices(flightbookingContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public PassengerResponse ViewTicket(int PassengerId)
        {
            if(PassengerId <= 0)
            {
                Console.WriteLine("Invalid PassengerId");
            }
            PassengerResponse response = new PassengerResponse();

            //Returns passenger details using pasenger id. 
            response.passenger = dbContext.Passengers.Where(x => x.PassengerId == PassengerId).SingleOrDefault();
            //Error handling

            if (response.passenger == null)
                response.error="Passenger doesn't exist" ;

            return response;


        }

        public ErrorResponse BookATicket(int userid,string username, string email,string password, int contactid,int phone,string type, int flightinstID, int age, string sex)
        {

            ErrorResponse errorResponse = new ErrorResponse();
            if (userid == null||username==null||email==null||password==null|| phone==null)
            {
                errorResponse.error.Add("Invalid Operation");
            }
                

            //Create a passenger with given details
            Passenger newPassenger = new Passenger
            {
                PassengerId = dbContext.Passengers.Count() + 1,
                PassengerName =username,
                Type = type,
                SeatNo = dbContext.FlightInstances.Where(x => x.InstanceId == flightinstID).Count() + 1,
                UserId = userid,
                FlightInstId = flightinstID,
                EmailId = email,
                Phone = phone,
                Age = age,
                Sex = sex,
                Confirmed = "Yes",
                Cancelled = "N0"

            };
            dbContext.Passengers.Add(newPassenger);
            Console.WriteLine("Ticket Booked Successfully");

            return errorResponse;
        }

       

        

    }
}
