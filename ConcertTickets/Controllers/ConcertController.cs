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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("GroupOrArtistName,TicketsCount,EventDate,EventPlace,Price,Description,ImageURL,AgeLimit")] PartyConcert partyConcert)
        {
            if (!ModelState.IsValid)
            {
                return View(partyConcert);
            }
            _service.Add(partyConcert);
            return RedirectToAction(nameof(Index));
        }
    }
}
