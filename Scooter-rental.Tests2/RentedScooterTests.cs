using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scooter_rental.Core.Models;
using System;

namespace Scooter_rental.Tests2
{
    [TestClass]
    public class RentedScooterTests
    {
        private RentedScooter _rentedScooter;

        [TestMethod]
        public void RentedScooterCreation_IdStartTimeAndPricePerMinuteSetCorrectly()
        {
            // Arrange
            _rentedScooter = new RentedScooter();
            _rentedScooter.ScooterId = 1;
            _rentedScooter.StartTime = new DateTime(2020, 07, 06, 00, 30, 00);
            // Assert
            _rentedScooter.ScooterId.Should().Be(1);
            _rentedScooter.StartTime.Should().Be(new DateTime(2020, 07, 06, 00, 30, 00));
        }
    }
}
