﻿using Ex13_DronesAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

        public bool isDronePuttable(Flight flight, Drone drone)
        {
            if (flight.DroneId == -1) return false;
            GetFlights().Where(f => f.DroneId == drone.DroneId);


        }



    }
}
