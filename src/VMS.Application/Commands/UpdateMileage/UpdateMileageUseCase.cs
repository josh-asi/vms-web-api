using System.Threading.Tasks;
using VMS.Application.Repositories;
using VMS.Application.UnitOfWork;

namespace VMS.Application.Commands.UpdateMileage
{
    public class UpdateMileageUseCase : IUpdateMileageUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateMileageUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<UpdateMileageResult> Execute(int vehicleId, double newMileage)
        {
            var vehicle = await unitOfWork.VehicleRepository.FindByIdAsync(vehicleId);

            if (vehicle == null) throw new RecordNotFoundException("Vehicle does not exist");

            vehicle.Mileage.UpdateMileage(newMileage);

            await unitOfWork.CommitAsync();

            return new UpdateMileageResult
            {
                VehicleId = vehicle.Id,
                Mileage = vehicle.Mileage
            };
        }
    }
}
