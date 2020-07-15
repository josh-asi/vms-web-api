using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMS.Application.UseCases.DeleteVehicle;
using ApplicationException = VMS.Application.Exceptions.ApplicationException;

namespace VMS.Api.UseCases.DeleteVehicle
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IDeleteVehicleUseCase deleteVehicleService;

        public VehicleController(IDeleteVehicleUseCase deleteVehicleService)
        {
            this.deleteVehicleService = deleteVehicleService;
        }

        [HttpDelete, Route("{vehicleId}")]
        public async Task<ActionResult> DeleteVehicleAsync(int vehicleId)
        {
            try
            {
                await deleteVehicleService.Execute(vehicleId);
                return Ok(vehicleId);
            }
            catch (ApplicationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
