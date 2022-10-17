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
            return Ok(Service.GetFlights());
        }

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public IActionResult GetFlightById(int id)
        {
            return Ok(Service.GetFlights().Where(flight => flight.FlightId == id));
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
    }
}
