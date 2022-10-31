using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scooter_rental.Core.Models;

namespace Scooter_rental.Tests
{

    [TestClass]
    public class ScooterTests
    {
        private Scooter _scooter;

        [TestMethod]
        public void ScooterCreation_IsRentedAndPricePerMinuteSetCorrectly()
        {
            // Arrange
            _scooter = new Scooter();
            _scooter.PricePerMinute = 0.2m;
            // Assert
            _scooter.PricePerMinute.Should().Be(0.2m);
            _scooter.IsRented.Should().BeFalse();
        }
    }
}
