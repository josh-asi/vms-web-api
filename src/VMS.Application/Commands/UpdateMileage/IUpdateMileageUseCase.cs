using System.Threading.Tasks;

namespace VMS.Application.Commands.UpdateMileage
{
    public interface IUpdateMileageUseCase
    {
        Task<UpdateMileageResult> Execute(int vehicleId, double newMileage);
    }
}
