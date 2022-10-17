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

        public static bool PostFlight(Flight flight)
        {
            var flightList = FileHelper.ReadAndDesirializeFile<Flight>(FlightPath).ToList();

            flightList.Add(flight);

            FileHelper.SerializeAndWrite<Flight>(flightList, FlightPath);

            return true;
            
        }

        public static Drone AddDrone(Drone drone)
        {
            var fileContent = FileHelper.ReadAndDesirializeFile<Drone>(DronePath);
            if(fileContent == null)
            {
                List<Drone> drones = new();
                drones.Add(drone);
                FileHelper.SerializeAndWrite(drones, DronePath);
                return drone;
            }
            var droneList = fileContent.ToList();
            droneList.Add(drone);
            FileHelper.SerializeAndWrite(droneList, DronePath);
            return drone;
        }
    }
}
