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
        //Task<IEnumerable<PartyConcert>> GetAll();
        //Task<IEnumerable<ClassicalConcert>> GetAll();
        //Task<IEnumerable<OpenAirConcert>> GetAll();
        Concert Update(int id, Concert newConcert);
        void AddParty(PartyConcert partyConcert);
        void AddClassical(ClassicalConcert classicalConcert);
        void AddOpenAir(OpenAirConcert openAirConcert);
    }
}
