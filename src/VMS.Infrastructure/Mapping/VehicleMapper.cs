using VMS.Application.DTOs.Vehicle;
using VMS.Application.Mapping;
using VMS.Domain.Aggregates.VehicleAggregate;

namespace VMS.Infrastructure.Mapping
{
    public class VehicleMapper : IMapper<Vehicle, VehicleDTO>
    {
        public VehicleDTO Map(Vehicle source)
        {
            return new VehicleDTO
            (
                source.Id,
                source.Speed,
                source.Mileage,
                source.VehicleType.ToFriendlyString()
            );
        }
    }
}
