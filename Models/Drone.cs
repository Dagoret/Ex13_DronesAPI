namespace Ex13_DronesAPI.Models
{
    public enum PropulsionTypes
    {
        Reaction = 0,
        FixedWing = 1,
        Helix = 2
    }
    public enum PilotTypes
    {
        Pilot = 0,
        AI = 1
    }
    public class Drone
    {
        public int DroneId { get; set; }
        //public TimeSpan FlightTime { get; set; }
        public PropulsionTypes PropulsionType { get; set; }
        public PilotTypes PilotType { get; set; }
    }
}
