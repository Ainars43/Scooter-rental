using Scooter_rental.Core.Interfaces;

namespace Scooter_rental.Core.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}