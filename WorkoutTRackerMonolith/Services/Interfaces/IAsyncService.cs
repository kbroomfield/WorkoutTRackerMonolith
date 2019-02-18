using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkoutTRackerMonolith.Services
{
    public interface IAsyncService<T>
    {
        Task<T> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<T> Delete(T entity);
    }
}