using System.Threading.Tasks;
using VMS.Application.DTOs.Vehicle;

namespace VMS.Application.Commands.AddVehicle
{
    public interface IAddVehicleUseCase
    {
        Task<VehicleDTO> Execute(int type, double speed, double mileage);
    }
}
