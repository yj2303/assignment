using Assignment3.Models;

namespace Assignment3.services
{
    public class AdminServices
    {
        private readonly flightbookingContext dbContext;
        public AdminServices(flightbookingContext dbContext)
        {
            this.dbContext = dbContext;

        }

        public  ErrorResponse  UpdateFlightDetails(int RouteId, int PlaneId)
        {

            ErrorResponse response = new ErrorResponse();
            //checking unit test case
            if (RouteId<= 0 || PlaneId<=0)
                response.error.Add($"Invalid Inputs");
            

            var ExistingAirplaneWithPlaneID = dbContext.RoutePlanes.Where(x => x.PlaneId == PlaneId).SingleOrDefault();

            
            if (ExistingAirplaneWithPlaneID == null)
                response.error.Add($"Plane with ID '{PlaneId}' was not found!");

            ExistingAirplaneWithPlaneID.RouteId = RouteId;
            return response;
        }





    }
}
