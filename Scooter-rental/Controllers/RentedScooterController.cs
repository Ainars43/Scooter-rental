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
        private readonly IScooterService _scooterService;
        private readonly IRentalCompanyService _rentalCompanyService;

        public RentedScooterController(IRentedScooterService rentedScooterService, IScooterService scooterService, IRentalCompanyService rentalCompanyService)
        {
            _rentedScooterService = rentedScooterService;
            _scooterService = scooterService;
            _rentalCompanyService = rentalCompanyService;
        }

        [HttpPost]
        [Route("startRent")]
        public IActionResult StartRent(int id)
        {
            if (_scooterService.IsValidScooterId(id))
            {
                BadRequest();
            }

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
            if (_rentedScooterService.IsValidRentedScooterId(id))
            {
                BadRequest();
            }

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
            var income = _rentalCompanyService.GetRentalIncome(year, includeNotCompleted);

            return Ok(income);
        }
    }
}
