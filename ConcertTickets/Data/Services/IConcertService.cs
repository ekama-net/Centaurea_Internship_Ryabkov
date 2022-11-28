using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConcertTickets
{
    public interface IConcertService
    {
        Task<IEnumerable<Concert>> GetAll();
        Concert GetById(int id);
        void Add(Concert concert);
        Concert Update(int id, Concert newConcert);
        void Delete(int id);
    }
}
