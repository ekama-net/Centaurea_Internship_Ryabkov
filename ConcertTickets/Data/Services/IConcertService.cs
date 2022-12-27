using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertTickets
{
    public interface IConcertService
    {
        Task<Concert> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        void AddConcert<T>(T concert) where T : class;
        void Update<T>(int id, T concert) where T : class;
        Task<IndexViewModel> GetAllAsync(string type, string searchString, int page);
    }
}
