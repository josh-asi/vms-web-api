using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VMS.Application.Commands.UpdateMileage;
using VMS.Application.Repositories;
using VMS.Domain;

namespace VMS.Api.UseCases.UpdateMileage
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUpdateMileageUseCase updateMileageService;

        public VehicleController(IUpdateMileageUseCase updateMileageService)
        {
            this.updateMileageService = updateMileageService;
        }

        [HttpPut, Route("Mileage")]
        public async Task<ActionResult> UpdateMileageAsync([FromBody] UpdateMileageRequest request)
        {
            try
            {
                return Ok(await updateMileageService.Execute(request.VehicleId, request.NewMilleage));
            }
            catch (RecordNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
