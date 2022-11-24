using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertTickets
{
    public class ConcertController : Controller
    {
        private readonly AppDbContext _context;

        public ConcertController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Concerts.ToListAsync();
            return View(data);
        }
    }
}
