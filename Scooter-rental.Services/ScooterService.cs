using System.Collections.Generic;
using System.Linq;
using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;
using Scooter_rental.Data;

namespace Scooter_rental.Services
{
    public class ScooterService : EntityService<Scooter>, IScooterService
    {
        public ScooterService(IScooterRentalDbContext context) : base (context) { }

        public List<Scooter> GetAllScooters()
        {
            return _context.Scooters.ToList();
        }

        public void DeleteScooterById(int id)
        {
            var scooter = GetScooterById(id);

            if (scooter != null)
            {
                Delete(scooter);
            }
        }

        public Scooter GetScooterById(int id)
        {
            return Query().SingleOrDefault(s => s.Id == id);
        }
    }
}