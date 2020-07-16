using System.Threading.Tasks;
using VMS.Application.Exceptions;
using VMS.Application.Repositories;
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
            catch (RecordNotFoundException e)
            {
                await unitOfWork.RollBackAsync();
                throw e;
            }
            catch
            {
                await unitOfWork.RollBackAsync();
                throw new ApplicationException("Failed to delete task");
            }

            await unitOfWork.CommitAsync();
        }
    }
}
