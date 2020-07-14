using System;
using VMS.Domain.Aggregates.VehicleAggregate;
using Xunit;

namespace VMS.Tests.Domain
{
    public class MileageTests
    {
        [Fact]
        public void Mileage_Should_Only_Be_Increased()
        {
            var mileage = new Kilometres(100.0f);
            var newMileage = new Kilometres(120.0f);

            mileage.UpdateMileage(newMileage);
            Assert.Equal(newMileage, mileage);

            Assert.Throws<InvalidOperationException>(() => mileage.UpdateMileage(90.0f));
        }
    }
}
