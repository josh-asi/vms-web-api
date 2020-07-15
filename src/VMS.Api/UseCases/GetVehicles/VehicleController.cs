using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Threading.Tasks;
using VMS.Application.Queries;

namespace VMS.Api.UseCases.GetVehicles
{
    [Route("api/Vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleQueries vehicleQueries;

        public VehicleController(IVehicleQueries vehicleQueries)
        {
            this.vehicleQueries = vehicleQueries;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetVehiclesAsync()
        {
            try
            {
                return Ok(await vehicleQueries.GetAllVehiclesAsync());
            }
            catch (DataException)
            {
                return BadRequest("An error occured.");
            }
        }
    }
}
