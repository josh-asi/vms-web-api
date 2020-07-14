using NSubstitute;
using VMS.Application.Commands.AddVehicle;
using VMS.Domain.Aggregates.VehicleAggregate;
using Xunit;

namespace VMS.Tests.UseCases
{
    public class AddVehicle : IClassFixture<VehicleFixture>
    {
        private readonly VehicleFixture vehicleFixture;

        public AddVehicle(VehicleFixture vehicleFixture)
        {
            this.vehicleFixture = vehicleFixture;
        }


        [Theory]
        [InlineData((int)VehicleType.Truck, 100.0, 1000.0)]
        [InlineData((int)VehicleType.Bus, 100.0, 1000.0)]
        public async void AddVehicleUseCase(int vehicleType, double speed, double mileage)
        {
            var id = 1;
            var type = vehicleType.ToVehicleType();
            var vehicle = new Vehicle(type, speed, mileage);

            vehicleFixture.UnitOfWork.VehicleRepository.AddAsync(vehicle).ReturnsForAnyArgs(id);

            var addVehicleUseCase = new AddVehicleUseCase(vehicleFixture.UnitOfWork, vehicleFixture.Mapper);

            var result = await addVehicleUseCase.Execute(vehicleType, speed, mileage);

            Assert.Equal(id, result.Id);
            Assert.Equal(type.ToFriendlyString(), result.Type);
            Assert.Equal(speed, result.Speed);
            Assert.Equal(mileage, result.Mileage);
        }
    }
}
