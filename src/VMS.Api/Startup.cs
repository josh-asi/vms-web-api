using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VMS.Application.Commands.AddVehicle;
using VMS.Application.Commands.UpdateMileage;
using VMS.Application.Queries;
using VMS.Application.Repositories;
using VMS.Application.UnitOfWork;
using VMS.Application.UseCases.DeleteVehicle;
using VMS.Infrastructure.Data.EntityFramework.Entities;
using VMS.Infrastructure.Data.EntityFramework.Queries;
using VMS.Infrastructure.Data.EntityFramework.Repositories;
using VMS.Infrastructure.Data.EntityFramework.UnitOfWork;
using VMS.Infrastructure.Mapping;

namespace VMS.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VMS API", Version = "v1" });
            });

            var connectionString = Configuration.GetConnectionString("VMS_DB");
            services.AddDbContext<VMSContext>(options => options.UseSqlServer(connectionString));

            // Commands
            services.AddScoped<IAddVehicleUseCase, AddVehicleUseCase>();
            services.AddScoped<IDeleteVehicleUseCase, DeleteVehicleUseCase>();
            services.AddScoped<IUpdateMileageUseCase, UpdateMileageUseCase>();

            // Queries
            services.AddScoped<IVehicleQueries, VehicleQueries>();

            // Unit of Work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            // Automapper
            IMapper mapper = AutoMapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VMS API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
