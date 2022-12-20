using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertTickets
{
    public class ConcertService : IConcertService
    {
        private readonly AppDbContext _context;

        public ConcertService(AppDbContext context)
        {
            _context = context;
        }

        public void AddParty(PartyConcert partyConcert)
        {
            _context.PartyConcerts.Add(partyConcert);
            _context.SaveChanges();
        }
        public void AddClassical(ClassicalConcert classicalConcert)
        {
            _context.ClassicalConcerts.Add(classicalConcert);
            _context.SaveChanges();
        }
        public void AddOpenAir(OpenAirConcert openAirConcert)
        {
            _context.OpenAirConcerts.Add(openAirConcert);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Concert>> GetAllAsync()
        {
            var result = await _context.Concerts.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Concert>> GetAllAsync(ConcertType type)
        {
            var allList = await _context.Concerts.ToListAsync();
            var result = new List<Concert>();
            foreach (var item in allList)
            {
                if (item.Discriminator == type.ToString())
                    result.Add(item);
            }
            return result;
        }

        public async Task<IEnumerable<Concert>> GetAllAsync(string searchString)
        {
            var data = await _context.Concerts.ToListAsync();
            var result = from m in data
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.GroupOrArtistName!.ToUpper().Contains(searchString.ToUpper()));
            }
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var concert = await _context.Concerts
               .FirstOrDefaultAsync(n => n.ConcertId == id);
            _context.Concerts.Remove(concert);
            _context.SaveChanges();
        }

        public async Task<Concert> GetByIdAsync(int id)
        {
            var concertDetails = await _context.Concerts
                .FirstOrDefaultAsync(n => n.ConcertId == id);
            return concertDetails;
        }

        public Concert Update(int id, Concert newConcert)
        {
            throw new System.NotImplementedException();
        }

    }
}
