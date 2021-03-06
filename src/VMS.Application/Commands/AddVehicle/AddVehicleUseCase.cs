﻿using AutoMapper;
using System.Threading.Tasks;
using VMS.Application.DTOs.Vehicle;
using VMS.Application.UnitOfWork;
using VMS.Domain.Aggregates.VehicleAggregate;

namespace VMS.Application.Commands.AddVehicle
{
    public class AddVehicleUseCase : IAddVehicleUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddVehicleUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<VehicleDTO> Execute(int type, double speed, double mileage)
        {
            var newVehicle = new Vehicle(type.ToVehicleType(), new Speed(speed), new Kilometres(mileage));
            var vehicleId = await unitOfWork.VehicleRepository.AddAsync(newVehicle);
            newVehicle.Id = vehicleId;
            return mapper.Map<VehicleDTO>(newVehicle);
        }
    }
}
