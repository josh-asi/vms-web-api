using VMS.Domain;
using VMS.Domain.Aggregates.VehicleAggregate;
using Xunit;

namespace VMS.Tests.Domain
{
    public class VehicleTypeTests
    {
        [Fact]
        public void VehicleType_Should_Be_Within_Rage()
        {
            Assert.Throws<DomainException>(() => 0.ToVehicleType());
            Assert.Throws<DomainException>(() => 3.ToVehicleType());
            Assert.Equal(VehicleType.Truck, ((int)VehicleType.Truck).ToVehicleType());
        }
    }
}
