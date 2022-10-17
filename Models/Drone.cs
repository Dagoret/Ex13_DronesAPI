﻿namespace Ex13_DronesAPI.Models
{
    public enum PropulsionTypes
    {
        Reaction = 1,
        FixedWing = 2,
        Helix = 3
    }
    public enum PilotTypes
    {
        Pilot = 0,
        AI = 1
    }
    public class Drone
    {
        public int DroneId { get; set; }
        public TimeSpan FlightTime { get; set; }
        public int PropulsionType { get; set; }
        public int PilotType { get; set; }
    }
}
