using System.Threading.Tasks;
using VMS.Application.Repositories;
using VMS.Application.UnitOfWork;
using VMS.Infrastructure.Data.EntityFramework.Entities;
using VMS.Infrastructure.Data.EntityFramework.Repositories;

namespace VMS.Infrastructure.Data.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VMSContext context;

        public UnitOfWork(VMSContext context)
        {
            this.context = context;
        }

        public IVehicleRepository VehicleRepository => new VehicleRepository(context);

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task RollBackAsync()
        {
            await context.DisposeAsync();
        }
    }
}
