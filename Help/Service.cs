using Ex13_DronesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ex13_DronesAPI.Help
{
    public static class Service
    {
        private static string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string DronePath { get; private set; } = $"{currentDirectory}..\\..\\..\\Files\\Drones.txt";
        public static string FlightPath { get; private set; } = $"{currentDirectory}..\\..\\..\\Files\\Flights.txt";

        
        public static IEnumerable<Flight> GetFlights()
        {
            return FileHelper.ReadAndDesirializeFile<Flight>(FlightPath);
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

            var updatedFlightList = flightList.ToList();
            updatedFlightList.Add(flight);

            FileHelper.SerializeAndWrite<Flight>(updatedFlightList.OrderBy(x => x.FlightId), FlightPath);

            return true;
            
        }

        public static void UpdateFlight(Flight flight)
        {
            var updatedFlights = GetFlights().Where(fl => fl.FlightId != flight.FlightId).ToList();
            updatedFlights.Add(flight);

            FileHelper.SerializeAndWrite(updatedFlights, FlightPath);
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

        public static List<Drone> GetDrones()
        {
            var fileContent = FileHelper.ReadAndDesirializeFile<Drone>(DronePath);
            if (fileContent == null) return null;
            return fileContent.ToList<Drone>();
        }

        private static bool isFlightAvailable(Flight flight)
        {
            if (flight.DroneId == -1) return false;
            return true;
        }

        public static bool isDronePuttable(Flight flight, Drone drone)
        {
            bool puttable = false;

            if(isFlightAvailable(flight)) puttable = true;

            //ritorna vero se c'è almeno un volo non compatibile con quello a cui vogliamo associare il drone
            var isFlightDoable = GetFlights()
                .Where(f => f.DroneId == drone.DroneId &&
                ((flight.DepartureDate < f.DepartureDate && 
                    flight.ArrivalDate < f.DepartureDate) ||
                flight.DepartureDate > f.ArrivalDate)).Any();

            if (isFlightDoable) puttable = false;
            else puttable = true;

            return puttable;

        }



    }
}
