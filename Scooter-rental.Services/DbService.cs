using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;
using Scooter_rental.Data;

namespace Scooter_rental.Services
{
    public class DbService : IDbService
    {
        protected readonly IScooterRentalDbContext _context;

        public DbService(IScooterRentalDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            return _context.Set<T>();
        }

        public IEnumerable<T> Get<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T GetByID<T>(int id) where T : Entity
        {
            return _context.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public void Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}