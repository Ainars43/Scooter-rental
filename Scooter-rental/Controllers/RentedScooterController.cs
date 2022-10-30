using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;

namespace Scooter_rental.Controllers
{
    [Route("rentedScooter-api")]
    [ApiController]
    public class RentedScooterController : ControllerBase
    {
        private readonly object _locker = new object();
        private readonly IRentedScooterService _rentedScooterService;

        public RentedScooterController(IRentedScooterService rentedScooterService)
        {
            _rentedScooterService = rentedScooterService;
        }

        [HttpPost]
        [Route("startRent")]
        public IActionResult StartRent(int id)
        {
            lock (_locker)
            {
                var rentedScooter = _rentedScooterService.StartScooterRent(id);
                _rentedScooterService.Create(rentedScooter);

                return Created("", rentedScooter);
            }
        }

        [HttpPut]
        [Route("endRent")]
        public IActionResult EndRent(int id)
        {
            lock (_locker)
            {
                var rentedScooter = _rentedScooterService.EndScooterRent(id);
                _rentedScooterService.Update(rentedScooter);

                return Ok();
            }
        }

        [HttpGet]
        [Route("getIncome")]
        public IActionResult GetIncome(int? year, bool includeNotCompleted)
        {
            return Ok();
        }
    }
}
