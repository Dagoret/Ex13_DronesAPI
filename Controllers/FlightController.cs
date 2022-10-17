using Microsoft.AspNetCore.Mvc;
using Ex13_DronesAPI.Help;
using Ex13_DronesAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex13_DronesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        // GET: api/<FlightController>
        [HttpGet]
        public IActionResult GetAllFlights()
        {
            var flights = Service.GetFlights();
            if (flights == null) NoContent();
            return Ok(flights);
        }

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public IActionResult GetFlightById(int id)
        {
            var flight = Service.GetFlightById(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        // POST api/<FlightController>
        [HttpPost]
        public IActionResult Post([FromBody] Flight flight)
        {
            return Ok(Service.PostFlight(flight));
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPut("{flightId}/drone/{droneId}")]
        public IActionResult PutDroneIntoFlight(int flightId, int droneId)
        {
            var flight = Service.GetFlights().Where(fl => fl.FlightId == flightId).FirstOrDefault();
            var drone = Service.GetDrones().Where(dr => dr.DroneId == droneId).FirstOrDefault();
            if (drone == null || flight == null) return NotFound();

            if(Service.isDronePuttable(flight, drone))
            {
                flight.DroneId = droneId;
                Service.UpdateFlight(flight);
                return Ok(drone);
            }
            return BadRequest("The drone cannot be associated to the flight");
        }
    }
}
