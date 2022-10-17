namespace Ex13_DronesAPI.Models
{
    public class Drone
    {
        public int DroneId { get; set; }
        public TimeSpan FlightTime { get; set; }
        public int PropulsionType { get; set; }
        public int PilotType { get; set; }
    }
}
