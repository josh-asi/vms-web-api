using AutoMapper;
using VMS.Application.DTOs.Vehicle;
using VMS.Domain.Aggregates.VehicleAggregate;

namespace VMS.Infrastructure.Mapping
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDTO>()
                .ForMember(dest => dest.Id, m => m.MapFrom(source => source.Id))
                .ForMember(dest => dest.Speed, m => m.MapFrom(source => source.Speed))
                .ForMember(dest => dest.Mileage, m => m.MapFrom(source => source.Mileage))
                .ForMember(dest => dest.Type, m => m.MapFrom(source => source.VehicleType.ToFriendlyString()));
        }
    }
}
