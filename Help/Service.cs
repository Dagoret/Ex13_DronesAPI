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
            return flightList.ToList();
        }

        public static bool PostFlight 
    }
}
