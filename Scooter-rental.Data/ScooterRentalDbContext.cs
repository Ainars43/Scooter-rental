using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scooter_rental.Core.Models;

namespace Scooter_rental.Data
{
    public class ScooterRentalDbContext : DbContext, IScooterRentalDbContext
    {
        public ScooterRentalDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<RentedScooter> RentedScooters { get; set; }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}