﻿using Ex13_DronesAPI.Help;
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
    public IActionResult PostDrone([FromBody] Drone drone) =>
        CreatedAtAction($"drones/{drone.DroneId}", Service.AddDrone(drone));



}
