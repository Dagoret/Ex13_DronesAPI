namespace Ex13_DronesAPI.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateOnly DepartureDate { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public int DroneId { get; set; }
    }
}
