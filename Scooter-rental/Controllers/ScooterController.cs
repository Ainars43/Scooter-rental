using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;
using Scooter_rental.Data;
using Scooter_rental.Services;

namespace Scooter_rental.Controllers
{
    [Route("scooter-api")]
    [ApiController, EnableCors]
    public class ScooterController : ControllerBase
    {
        private readonly object _locker = new object();
        private readonly IScooterService _scooterService;


        public ScooterController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }


        [HttpGet]
        [Route("getAllScooters")]
        public IActionResult GetScooters()
        {
            return Ok(_scooterService.GetAllScooters());
        }


        [HttpPost]
        [Route("createScooter")]
        public IActionResult AddScooter(Scooter scooter)
        {
            lock (_locker)
            {
                _scooterService.Create(scooter);

                return Created("", scooter);
            }
        }


        [HttpDelete]
        [Route("deleteScooter")]
        public IActionResult DeleteScooter(int id)
        {
            lock (_locker)
            {
                _scooterService.DeleteScooterById(id);

                return Ok();
            }
        }

        [HttpPut]
        [Route("updateScooter")]
        public IActionResult UpdateScooter(Scooter scooter)
        {
            lock (_locker)
            {
                _scooterService.Update(scooter);

                return Ok();
            }
        }
    }
}
