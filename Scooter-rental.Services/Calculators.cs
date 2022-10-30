using System;
using Scooter_rental.Core.Interfaces;
using System.Linq;
using Scooter_rental.Core.Models;
using Scooter_rental.Data;

namespace Scooter_rental.Services
{
    public class Calculators : EntityService<RentedScooter>, ICalculators
    {
        private readonly IScooterService _service;

        public Calculators(IScooterRentalDbContext context, IScooterService service) : base(context)
        {
            _service = service;
        }

        public decimal FeeCalculator(DateTime startRent, DateTime endRent, decimal pricePerMinute)
        {
            const int minutesInDay = 1440;
            decimal feeForFullRentedDay = (endRent.DayOfYear - startRent.DayOfYear - 1) * (minutesInDay * pricePerMinute);
            decimal feeForFirstDay = (int)(minutesInDay - startRent.TimeOfDay.TotalMinutes) * pricePerMinute;
            decimal feeForLastDay = (int)endRent.TimeOfDay.TotalMinutes * pricePerMinute;
            decimal feeForOneDay = (int)(endRent.TimeOfDay.TotalMinutes - startRent.TimeOfDay.TotalMinutes) * pricePerMinute;

            return (endRent.DayOfYear - startRent.DayOfYear) switch
            {
                > 1 => feeForFullRentedDay + feeForFirstDay + feeForLastDay,
                1 => feeForFirstDay + feeForLastDay,
                _ => feeForOneDay,
            };
        }

        public decimal GetIncomeByThisYearIncludeNotCompleted(int year)
        {
            decimal income = 0;
            foreach (var rent in Query().Where(r => !r.EndTime.HasValue))
            {
                var scooter = _service.GetScooterById(rent.ScooterId);
                rent.Fee = FeeCalculator(rent.StartTime, DateTime.UtcNow, scooter.PricePerMinute);
                income += (decimal)rent.Fee;
            }

            return Query().Where(r => r.EndTime.HasValue && r.EndTime.Value.Year == year).Sum(r => (decimal)r.Fee) + income;
        }

        public decimal GetIncomeByYear(int year)
        {
            return Query().Where(r => r.EndTime.HasValue && r.EndTime.Value.Year == year).Sum(r => (decimal)r.Fee);
        }

        public decimal GetIncome()
        {
            return Query().Where(r => r.EndTime.HasValue ).Sum(r => (decimal)r.Fee);
        }
    }
}