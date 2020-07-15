using NSubstitute;
using System.Threading.Tasks;
using VMS.Application.Commands.UpdateMileage;
using VMS.Application.Repositories;
using Xunit;

namespace VMS.Tests.UseCases
{
    public class UpdateMileage : IClassFixture<VehicleFixture>
    {
        private readonly VehicleFixture vehicleFixture;

        public UpdateMileage(VehicleFixture vehicleFixture)
        {
            this.vehicleFixture = vehicleFixture;
        }

        [Theory]
        [InlineData(1, 9999)]
        [InlineData(1, 98989.1234)]
        public async void UpdateMileageUseCase(int vehicleId, double newMileage)
        {
            vehicleFixture.UnitOfWork.VehicleRepository.FindByIdAsync(vehicleId).Returns(Task.FromResult(vehicleFixture.Truck));

            var updateMileageUseCase = new UpdateMileageUseCase(vehicleFixture.UnitOfWork);

            var result = await updateMileageUseCase.Execute(vehicleId, newMileage);

            Assert.Equal(vehicleId, result.VehicleId);
            Assert.Equal(newMileage, result.Mileage);
        }

        [Fact]
        public async void Should_Throw_A_Not_Found_Exception()
        {
            var updateMileageUseCase = new UpdateMileageUseCase(vehicleFixture.UnitOfWork);
            await Assert.ThrowsAsync<RecordNotFoundException>(async () => await updateMileageUseCase.Execute(99, 9999));
        }
    }
}
