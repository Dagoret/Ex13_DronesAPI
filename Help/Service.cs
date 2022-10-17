using Ex13_DronesAPI.Models;

namespace Ex13_DronesAPI.Help
{
    public static class Service
    {
        private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string DronePath { get; private set; } = $"{currentDirectory}..\\..\\..\\Files\\Drones.txt";
        public static string FlightPath { get; private set; } = $"{currentDirectory}..\\..\\..\\Files\\Flights.txt";

        
        public static List<Flight> GetFlights()
        {
            var flightList = FileHelper.ReadAndDesirializeFile<Flight>(FlightPath);

            if (flightList is null)
            {
                var newFlightList = new List<Flight>();
                return newFlightList;
            }

            return flightList.ToList();
        }

        public static Flight GetFlightById(int id)
        {

            var flight = GetFlights().FirstOrDefault<Flight>(flight => flight.FlightId == id);
            return flight;
        }

        public static bool PostFlight(Flight flight)
        {
            var flightList = FileHelper.ReadAndDesirializeFile<Flight>(FlightPath);

            if(flightList is null)
            {
                var newFlightList = new List<Flight>();
                newFlightList.Add(flight);
                FileHelper.SerializeAndWrite<Flight>(newFlightList, FlightPath);
                return true;
            }

            flightList.ToList().Add(flight);

            FileHelper.SerializeAndWrite<Flight>(flightList, FlightPath);

            return true;
            
        }
    }
}
