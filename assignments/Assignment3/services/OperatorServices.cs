//using assignment_3.Models;
using Assignment3.Models;

namespace Assignment3.services
{
    public class OperatorServices
    {
        private readonly flightbookingContext dbContext;
        public OperatorServices(flightbookingContext dbContext)
        {
            this.dbContext = dbContext;

        }

        //Add a new flight by creating an object and aading to the list and also performed error checking
        public ErrorResponse  addNewInstancesToRoutes(string name, int eseats, int bseats, int fseats, int routeID)
        {
            //checking the unit cases
            if(name==null || (eseats == 0 || bseats == 0 || fseats == 0) || routeID <= 0)
            {
                Console.WriteLine("Invalid Inputs");
            }
            ErrorResponse errorResponse = new ErrorResponse();
            var planeID = dbContext.Airplanes.Count() + 1;
            var newFlight = new Airplane
            {
                AirplaneId = planeID,
                Name = name,
                ESeats = eseats,
                BSeats = bseats,
                FSeats = fseats
            };
            dbContext.Airplanes.Add(newFlight);
            dbContext.SaveChanges();

            if (dbContext.Routes.Where(x => x.RouteId == routeID).SingleOrDefault() == null)
                errorResponse.error.Add("Route doesn't exist");

            var route = new RoutePlane
            {
                RouteId = routeID,
                PlaneId = planeID
            };
            dbContext.RoutePlanes.Add(route);
            Console.WriteLine("New Instance Added Successfully");
            return errorResponse;
        }


      
    }
}
