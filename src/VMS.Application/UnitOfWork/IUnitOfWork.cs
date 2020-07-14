using System.Threading.Tasks;
using VMS.Application.Repositories;

namespace VMS.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RollBackAsync();
        IVehicleRepository VehicleRepository { get; }
    }
}
