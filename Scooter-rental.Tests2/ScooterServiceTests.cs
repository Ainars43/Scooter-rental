using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scooter_rental.Core.Interfaces;
using Scooter_rental.Core.Models;
using Scooter_rental.Services;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Scooter_rental.Data;

namespace Scooter_rental.Tests2
{
    [TestClass]
    public class ScooterServiceTests
    {
        [TestMethod]
        public void GetAllScooters_GetAllScootersFromMockedAScooterList()
        {
            var data = new List<Scooter>
            {
                new Scooter { IsRented = false, PricePerMinute = 0.2m},
                new Scooter { IsRented = false, PricePerMinute = 0.3m },
                new Scooter { IsRented = false, PricePerMinute = 0.4m },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Scooter>>();
            mockSet.As<IQueryable<Scooter>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Scooter>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Scooter>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Scooter>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<ScooterRentalDbContext>();
            mockContext.Setup(c => c.Scooters).Returns(mockSet.Object);

            var service = new ScooterService(mockContext.Object);
            var scooters = service.GetAllScooters();

            Assert.AreEqual(3, scooters.Count);
            Assert.AreEqual(false, scooters[0].IsRented);
            Assert.AreEqual(false, scooters[1].IsRented);
            Assert.AreEqual(false, scooters[2].IsRented);
        }

        /*
        [TestMethod]
        public void CreateScooter_SavesAScooterViaContext()
        {
            var mockSet = new Mock<DbSet<Scooter>>();

            var mockContext = new Mock<ScooterRentalDbContext>();
            mockContext.Setup(m => m.Scooters).Returns(mockSet.Object);

            var service = new ScooterService(mockContext.Object);
            service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

            mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
        */
        
    }
}