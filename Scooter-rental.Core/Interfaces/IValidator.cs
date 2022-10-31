using Scooter_rental.Core.Models;

namespace Scooter_rental.Core.Interfaces
{
    public interface IValidator
    {
        bool Validate(Scooter scooter);
    }
}