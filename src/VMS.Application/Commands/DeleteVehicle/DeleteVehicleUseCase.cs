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
                throw e;
            }
            catch
            {
                throw new ApplicationException("Failed to delete task");
            }
            finally
            {
                await unitOfWork.RollBackAsync();
            }

            await unitOfWork.CommitAsync();
        }
    }
}
