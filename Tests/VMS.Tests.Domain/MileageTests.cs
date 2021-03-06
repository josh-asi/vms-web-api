﻿using VMS.Domain;
using VMS.Domain.Aggregates.VehicleAggregate;
using Xunit;

namespace VMS.Tests.Domain
{
    public class MileageTests
    {
        [Fact]
        public void Mileage_Should_Only_Be_Increased()
        {
            var mileage = new Kilometres(100.0);
            var newMileage = new Kilometres(120.0);

            mileage.UpdateMileage(newMileage);
            Assert.Equal(newMileage, mileage);

            Assert.Throws<DomainException>(() => mileage.UpdateMileage(90.0));
        }

        [Fact]
        public void Mileage_Should_Only_Be_Positive()
        {
            Assert.Throws<DomainException>(() => new Kilometres(-0.3));
        }
    }
}
