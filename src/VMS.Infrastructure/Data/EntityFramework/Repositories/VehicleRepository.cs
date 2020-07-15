using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VMS.Application.Repositories;
using VMS.Domain.Aggregates.VehicleAggregate;
using VMS.Infrastructure.Data.EntityFramework.Entities;
using Vehicle = VMS.Domain.Aggregates.VehicleAggregate.Vehicle;

namespace VMS.Infrastructure.Data.EntityFramework.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VMSContext context;

        public VehicleRepository(VMSContext context)
        {
            this.context = context;
        }
        public async Task<int> AddAsync(Vehicle vehicle)
        {
            var newVehicle = new Entities.Vehicle
            {
                Mileage = vehicle.Mileage,
                Speed = vehicle.Speed,
                CreatedDttm = DateTime.Now,
                Type = (int)vehicle.VehicleType
            };

            context.Add(newVehicle);
            await context.SaveChangesAsync();
            return newVehicle.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var vehicleToBeDeleted = await GetVehicleEntityAsync(id);
            context.Vehicle.Remove(vehicleToBeDeleted);
        }

        public async Task<Vehicle> FindByIdAsync(int id)
        {
            return await context.Vehicle.Where(v => v.Id == id)
                                        .Select(v => new Vehicle(v.Id,
                                                        v.Type.ToVehicleType(),
                                                        new Speed(v.Speed),
                                                        new Kilometres(v.Mileage)))
                                        .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            var vehicleToUpdate = await GetVehicleEntityAsync(vehicle.Id);

            vehicleToUpdate.Mileage = vehicle.Mileage;
            vehicleToUpdate.Speed = vehicle.Speed;
            vehicleToUpdate.Type = (int)vehicle.VehicleType;
        }

        private async Task<Entities.Vehicle> GetVehicleEntityAsync(int id)
        {
            return await context.Vehicle.FindAsync(id);
        }
    }
}
