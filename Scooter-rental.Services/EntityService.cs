using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;
using System.Collections.Generic;
using System.Linq;
using Scooter_rental.Data;

namespace Scooter_rental.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(IScooterRentalDbContext context) : base(context) { }

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public T GetByID(int id)
        {
            return GetByID<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }
    }
}