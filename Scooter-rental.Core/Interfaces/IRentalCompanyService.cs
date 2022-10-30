namespace Scooter_rental.Core.Interfaces
{
    public interface IRentalCompanyService
    {
        decimal GetRentalIncome(int? year, bool includeNotCompleted);
    }
}