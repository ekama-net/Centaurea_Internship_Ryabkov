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

        public async Task<IndexViewModel> GetAllAsync(int page)
        {
            IQueryable<Concert> source = _context.Concerts;

            int pageSize = 6;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Concerts = items
            };

            return viewModel;
        } 

        public async Task<IndexViewModel> GetAllAsync(ConcertType type, int page)
        {
            IQueryable<Concert> source = _context.Concerts.Where(i=>i.Discriminator == type.ToString());
            
            int pageSize = 6;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Concerts = items
            };

            return viewModel;
        }

        public async Task<IndexViewModel> GetAllAsync(string searchString, int page)
        {
            IQueryable<Concert> source = _context.Concerts.Where(s => s.GroupOrArtistName.ToUpper().Contains(searchString.ToUpper()));
            
            int pageSize = 6;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Concerts = items,
                SearchString = searchString               
            };

            return viewModel;
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

        public void Update<T>(int id,T concert) where T : class
        {
            if (concert is PartyConcert partyConcert)
            {
                PartyConcert dbconcert = _context.PartyConcerts.Where(p => p.ConcertId == id).FirstOrDefault();
                var UpdatedObj = (PartyConcert)Extensions.CheckUpdateObject(dbconcert, partyConcert);
                _context.Entry(dbconcert).CurrentValues.SetValues(partyConcert);
            }
            if (concert is ClassicalConcert classicalConcert)
            {
                ClassicalConcert dbconcert = _context.ClassicalConcerts.Where(p => p.ConcertId == id).FirstOrDefault();
                var UpdatedObj = (ClassicalConcert)Extensions.CheckUpdateObject(dbconcert, classicalConcert);
                _context.Entry(dbconcert).CurrentValues.SetValues(classicalConcert);
            }
            if (concert is OpenAirConcert openAirConcert)
            {
                OpenAirConcert dbconcert = _context.OpenAirConcerts.Where(p => p.ConcertId == id).FirstOrDefault();
                var UpdatedObj = (OpenAirConcert)Extensions.CheckUpdateObject(dbconcert, openAirConcert);
                _context.Entry(dbconcert).CurrentValues.SetValues(openAirConcert);
            }
            _context.SaveChanges();
        }
    }
}
