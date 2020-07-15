using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMS.Application.Queries;

namespace VMS.Api.UseCases.GetVehicleTypes
{
    [Route("api/[controller]/Types")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleQueries vehicleQueries;

        public VehicleController(IVehicleQueries vehicleQueries)
        {
            this.vehicleQueries = vehicleQueries;
        }

        [HttpGet]
        public async Task<ActionResult> GetVehicleTypesAsync()
        {
            try
            {
                return Ok(await vehicleQueries.GetAllVehicleTypesAsync());
            }
            catch
            {
                return BadRequest("Failed to get vehicle types");
            }
        }
    }
}
