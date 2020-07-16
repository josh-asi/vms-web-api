using System.Threading.Tasks;

namespace VMS.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> AddAsync(T model);
        Task UpdateAsync(T model);

        Task DeleteAsync(int id);

        Task<T> FindByIdAsync(int id);
    }
}
