using AutoMapper;

namespace VMS.Infrastructure.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<VehicleProfile>();
            });

            return config.CreateMapper();
        }
    }
}
