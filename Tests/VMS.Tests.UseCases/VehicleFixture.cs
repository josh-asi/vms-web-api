using NSubstitute;
using VMS.Application.DTOs.Vehicle;
using VMS.Application.Mapping;
using VMS.Application.UnitOfWork;
using VMS.Domain.Aggregates.VehicleAggregate;
using VMS.Infrastructure.Mapping;

namespace VMS.Tests.UseCases
{
    public class VehicleFixture
    {
        //public VehicleDTO TruckDTO => new VehicleDTO(1, 100.0, 1000.0, VehicleType.Truck.ToFriendlyString());
        //public VehicleDTO BusDTO => new VehicleDTO(1, 100.0, 1000.0, VehicleType.Bus.ToFriendlyString());

        public Vehicle Truck => new Vehicle(1, VehicleType.Truck, 100.0, 1000.0);
        public Vehicle Bus => new Vehicle(1, VehicleType.Bus, 100.0, 1000.0);

        public IMapper<Vehicle, VehicleDTO> Mapper => new VehicleMapper();

        public IUnitOfWork UnitOfWork { get; private set; }

        public VehicleFixture()
        {
            UnitOfWork = Substitute.For<IUnitOfWork>();
        }
    }
}
