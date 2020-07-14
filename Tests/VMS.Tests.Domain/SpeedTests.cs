using VMS.Domain;
using VMS.Domain.Aggregates.VehicleAggregate;
using Xunit;

namespace VMS.Tests.Domain
{
    public class SpeedTests
    {
        [Fact]
        public void Speed_Should_Not_Be_Negative()
        {
            Assert.Throws<DomainException>(() => new Speed(-1.0f));
        }
    }
}
