using System.Threading.Tasks;
using VMS.Application.Exceptions;
using VMS.Application.UnitOfWork;

namespace VMS.Application.UseCases.DeleteVehicle
{
    public class DeleteVehicleUseCase : IDeleteVehicleUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteVehicleUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Execute(int vehicleId)
        {
            try
            {
                await unitOfWork.VehicleRepository.DeleteAsync(vehicleId);
            }
            catch
            {
                await unitOfWork.RollBackAsync();
                throw new ApplicationException("Failed to delete vehicle.");
            }

            await unitOfWork.CommitAsync();
        }
    }
}
