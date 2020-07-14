using System.Collections.Generic;
using System.Threading.Tasks;
using VMS.Application.DTOs.Vehicle;

namespace VMS.Application.Queries
{
    public interface IVehicleQueries
    {
        Task<IEnumerable<VehicleDTO>> GetAllVehiclesAsync();
    }
}
