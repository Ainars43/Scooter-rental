using System;

namespace Scooter_rental.Core.Interfaces
{
    public interface ICalculators
    {
        decimal FeeCalculator(DateTime startRent, DateTime endRent, decimal pricePerMinute);
        decimal GetIncomeByThisYearIncludeNotCompleted(int year);
        decimal GetIncomeByYear(int year);
        decimal GetIncome();
    }
}