using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMS.Application.Commands.AddVehicle;
using VMS.Domain;

namespace VMS.Api.UseCases.AddVehicle
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IAddVehicleUseCase addVehicleService;

        public VehicleController(IAddVehicleUseCase addVehicleService)
        {
            this.addVehicleService = addVehicleService;
        }

        [HttpPost]
        public async Task<ActionResult> AddVehicleAsync([FromBody] AddVehicleRequest request)
        {
            try
            {
                return Ok(await addVehicleService.Execute(request.Type, request.Speed, request.Mileage));
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
