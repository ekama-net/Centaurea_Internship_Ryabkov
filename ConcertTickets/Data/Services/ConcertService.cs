using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public void AddConcert<T>(T concert) where T : class
        {
            if (concert is PartyConcert partyConcert)
            {
                _context.PartyConcerts.Add(partyConcert);
            }
            if (concert is ClassicalConcert classicalConcert)
            {
                _context.ClassicalConcerts.Add(classicalConcert);
            }
            if (concert is OpenAirConcert openAirConcert)
            {
                _context.OpenAirConcerts.Add(openAirConcert);
            }
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

        public void Update<T>(int id, T concert) where T : class
        {
           // EntityEntry entityEntry = ;
           //var concert = _context.Concerts.Where(i => i.ConcertId == id).FirstOrDefault();

            //_context.Entry<T>(concert).State = EntityState.Modified;
            //_context.SaveChanges();
        }

    }
}
