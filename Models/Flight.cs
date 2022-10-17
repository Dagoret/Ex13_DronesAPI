namespace Ex13_DronesAPI.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int DroneId { get; set; }
    }
}
