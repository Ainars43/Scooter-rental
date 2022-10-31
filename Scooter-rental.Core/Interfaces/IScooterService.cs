using System.Collections.Generic;
using Scooter_rental.Core.Models;

namespace Scooter_rental.Core.Interfaces
{
    public interface IScooterService : IEntityService<Scooter>
    {
        List<Scooter> GetAllScooters();
        void DeleteScooterById(int id);
        Scooter GetScooterById(int id);
        bool IsValidScooterId(int id);
    }
}