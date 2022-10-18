using Ex13_DronesAPI.Help;
using Ex13_DronesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Ex13_DronesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DroneController : ControllerBase
{
    //Serv
    [HttpPost]
    public IActionResult PostDrone([FromBody] DroneSimplified drone) 
    {
        var droneAdded = Service.AddDrone(drone);
        return CreatedAtAction(nameof(GetDroneById), new { id = droneAdded.DroneId}, droneAdded);
    }

    [HttpGet("{id}")]
    public IActionResult GetDroneById(int id)
    {
        var drone = Service.GetDroneById(id);
        if (drone == null) return NotFound();
        return Ok(drone);
    }


    [HttpGet]
    public IEnumerable<Drone> GetDrones()
    {
        return Service.GetDrones();
    }



}
