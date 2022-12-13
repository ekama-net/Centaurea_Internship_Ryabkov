using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ConcertTickets
{
        //[Authorize(Roles = UserRoles.Admin)]
        //[AllowAnonymous] TODO: Create Authorisation 
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

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAll();
            var concerts = from m in data
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                concerts = concerts.Where(s => s.GroupOrArtistName!.ToUpper().Contains(searchString.ToUpper()));
            }

            return View(concerts);
        }



        [HttpPost] //TODO: contunue after solve a problem with hierarchy
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
