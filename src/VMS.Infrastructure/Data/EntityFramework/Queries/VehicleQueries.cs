using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMS.Application.DTOs;
using VMS.Application.DTOs.Vehicle;
using VMS.Application.Queries;
using VMS.Infrastructure.Data.EntityFramework.Entities;

namespace VMS.Infrastructure.Data.EntityFramework.Queries
{
    public sealed class VehicleQueries : IVehicleQueries
    {
        private readonly VMSContext context;

        public VehicleQueries(VMSContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<VehicleDTO>> GetAllVehiclesAsync()
        {
            return await context.Vehicle.Select(v => new VehicleDTO
            {
                Id = v.Id,
                Mileage = v.Mileage,
                Speed = v.Speed,
                Type = v.TypeNavigation.Description
            }).ToArrayAsync();
        }

        public async Task<IEnumerable<VehicleTypeDTO>> GetAllVehicleTypesAsync()
        {
            return await context.VehicleType.Select(v => new VehicleTypeDTO
            {
                Id = v.Id,
                Description = v.Description
            }).ToArrayAsync();
        }
    }
}
