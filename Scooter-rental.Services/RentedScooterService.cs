using System;
using System.Linq;
using System.Net.Http;
using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;
using Scooter_rental.Data;

namespace Scooter_rental.Services
{
    public class RentedScooterService : EntityService<RentedScooter>, IRentedScooterService
    {
        private readonly IScooterService _scooterService;
        private readonly ICalculators _calculators;

        public RentedScooterService(IScooterRentalDbContext context, IScooterService scooterService, ICalculators calculators) : base(context)
        {
            _scooterService = scooterService;
            _calculators = calculators;
        }

        public RentedScooter StartScooterRent(int id)
        {
            var rentedScooter = new RentedScooter
            {
                ScooterId = id,
                StartTime = DateTime.UtcNow
            };
            var scooter = _scooterService.GetScooterById(id);
            scooter.IsRented = true;

            return rentedScooter;
        }

        public RentedScooter EndScooterRent(int id)
        {
            var rentedScooter = Query().SingleOrDefault(r => r.ScooterId == id && r.EndTime == null && r.Fee == null);
            var scooter = _scooterService.GetScooterById(id);

            rentedScooter.EndTime = DateTime.UtcNow;
            rentedScooter.Fee = _calculators.FeeCalculator(rentedScooter.StartTime, (DateTime)rentedScooter.EndTime, scooter.PricePerMinute);
            
            scooter.IsRented = false;
            
            return rentedScooter;
        }

        public bool IsValidRentedScooterId(int id)
        {
            return Query().Any(r => r.ScooterId == id);
        }
    }
}