using System.ComponentModel.DataAnnotations;

namespace VMS.Api.UseCases.UpdateMileage
{
    public sealed class UpdateMileageRequest

    {
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public double NewMileage { get; set; }
    }
}
