using System;
using Scooter_rental.Core.Interfaces;

namespace Scooter_rental.Services
{
    public class RentalCompanyService : IRentalCompanyService
    {
        private readonly ICalculators _calculators;

        public RentalCompanyService(ICalculators calculators)
        {
            _calculators = calculators;
        }

        public decimal GetRentalIncome(int? year, bool includeNotCompleted)
        {
            if (year == DateTime.Now.Year && includeNotCompleted)
            {
                return  _calculators.GetIncomeByThisYearIncludeNotCompleted((int)year);
            }
            else if (year != null)
            {
                return _calculators.GetIncomeByYear((int)year);
            }
            else
            {
                return _calculators.GetIncome();
            }
        }
    }
}