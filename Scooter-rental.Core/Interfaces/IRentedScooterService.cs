using Scooter_rental.Core.Models;

namespace Scooter_rental.Core.Interfaces
{
    public interface IRentedScooterService : IEntityService<RentedScooter>
    {
        RentedScooter StartScooterRent(int id);
        RentedScooter EndScooterRent(int id);
        bool IsValidRentedScooterId(int id);
    }
}