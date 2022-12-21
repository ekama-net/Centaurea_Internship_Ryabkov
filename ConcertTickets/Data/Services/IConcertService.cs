using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcertTickets
{
    public interface IConcertService
    {
        Task<IEnumerable<Concert>> GetAllAsync();
        Task<IEnumerable<Concert>> GetAllAsync(ConcertType type);
        Task<IEnumerable<Concert>> GetAllAsync(string searchString);
        Task<Concert> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        void AddConcert<T>(T concert) where T : class;
        void Update<T>(int id, T concert) where T : class;
    }
}
