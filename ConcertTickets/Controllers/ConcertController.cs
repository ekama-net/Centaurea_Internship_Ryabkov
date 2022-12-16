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
            var data = await _service.GetAllAsync();
            ViewBag.Title = "All Concerts";
            return View(data);
        }

        public async Task<IActionResult> FilterByType(ConcertType type)
        {
            var data = await _service.GetAllAsync(type);
            var title = type.ToString();
            ViewBag.Title = title.Remove(title.Length-7);
            return View("Index",data);
        }

        public async Task<IActionResult> FilterByName(string searchString)
        {
            var data = await _service.GetAllAsync(searchString);

            ViewBag.Title = $"Filter: {searchString}";
            return View("Index", data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var contertDetail = await _service.GetByIdAsync(id);
            ViewBag.Title = $"{contertDetail.GroupOrArtistName}";
            return View(contertDetail);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var contertDetail = await _service.GetByIdAsync(id);
            ViewBag.Title = $"Delete {contertDetail.GroupOrArtistName}";
            return View(contertDetail);
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
