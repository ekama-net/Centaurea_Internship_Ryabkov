using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConcertTickets
{
    public class ConcertController : Controller
    {
        private readonly IConcertService _service;

        public ConcertController(IConcertService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            return View(data);
        }
    }
}
