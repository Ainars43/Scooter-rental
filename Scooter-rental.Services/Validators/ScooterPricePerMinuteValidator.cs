using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;

namespace Scooter_rental.Services.Validators
{
    public class ScooterPricePerMinuteValidator : IValidator
    {
        public bool Validate(Scooter scooter)
        {
            return scooter.PricePerMinute > 0;
        }
    }
}