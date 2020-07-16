using System.Threading.Tasks;

namespace VMS.Application.UseCases.DeleteVehicle
{
    public interface IDeleteVehicleUseCase
    {
        Task Execute(int vehicleId);
    }
}
