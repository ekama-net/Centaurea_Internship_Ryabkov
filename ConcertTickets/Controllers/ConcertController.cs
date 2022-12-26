using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _service.GetAllAsync(page);
            ViewBag.Title = "All Concerts";
            return View(data);
        }

        public async Task<IActionResult> FilterByType(ConcertType type, int page)
        {
            var data = await _service.GetAllAsync(type,page);
            ViewBag.Title = type.ToString();
            return View("Index", data);
        }

        public async Task<IActionResult> FilterByName(string searchString, int page)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var data = await _service.GetAllAsync(searchString, page);
                ViewBag.Title = $"Filter: {searchString}";
                return View("Index", data);
            }
            return View("Index", await _service.GetAllAsync(page));
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
            if (contertDetail == null) return View("NotFound");
            ViewBag.Title = $"Delete {contertDetail.GroupOrArtistName}";
            return View(contertDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contertDetail = await _service.GetByIdAsync(id);
            if (contertDetail == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateParty()
        {
            return View();
        }

        public IActionResult CreateClassical()
        {
            return View();
        }

        public IActionResult CreateOpenAir()
        {
            return View();
        }

        [HttpPost] //TODO: how to make it better (Create and Edit)
        public IActionResult CreateParty([Bind("ImageURL,Description,Price,EventPlace,EventDate,TicketsCount,GroupOrArtistName,AgeLimit")] PartyConcert concert)
        {
            if (!ModelState.IsValid)
            {
                return View(concert);
            }
            _service.AddConcert(concert);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CreateClassical([Bind("ImageURL,Description,Price,EventPlace,EventDate,TicketsCount,GroupOrArtistName,СomposerName,ConcertName,VoiceType")] ClassicalConcert concert)
        {
            if (!ModelState.IsValid)
            {
                return View(concert);
            }
            _service.AddConcert(concert);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult CreateOpenAir([Bind("ImageURL,Description,Price,EventPlace,EventDate,TicketsCount,GroupOrArtistName,HowToGetTo,HeadLiner")] OpenAirConcert concert)
        {
            if (!ModelState.IsValid)
            {
                return View(concert);
            }
            _service.AddConcert(concert);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditParty(int id)
        {
            var contertDetail = await _service.GetByIdAsync(id);
            if (contertDetail == null) return View("NotFound");
            ViewBag.Title = $"Edit {contertDetail.GroupOrArtistName}";
            return View(contertDetail);
        }
        public async Task<IActionResult> EditClassical(int id)
        {
            var contertDetail = await _service.GetByIdAsync(id);
            if (contertDetail == null) return View("NotFound");
            ViewBag.Title = $"Edit {contertDetail.GroupOrArtistName}";
            return View(contertDetail);
        }
        public async Task<IActionResult> EditOpenAir(int id)
        {
            var contertDetail = await _service.GetByIdAsync(id);
            if (contertDetail == null) return View("NotFound");
            ViewBag.Title = $"Edit {contertDetail.GroupOrArtistName}";
            return View(contertDetail);
        }

        [HttpPost]
        public IActionResult EditParty(int id,[Bind("ImageURL,Description,Price,EventPlace,EventDate,TicketsCount,GroupOrArtistName,AgeLimit")] PartyConcert concert)
        {
            if (!ModelState.IsValid)
            {
                return View(concert);
            }
            _service.Update(id, concert);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditClassical(int id, [Bind("ImageURL,Description,Price,EventPlace,EventDate,TicketsCount,GroupOrArtistName,СomposerName,ConcertName,VoiceType")] ClassicalConcert concert)
        {
            if (!ModelState.IsValid)
            {
                return View(concert);
            }
            _service.Update(id, concert);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditOpenAir(int id, [Bind("ImageURL,Description,Price,EventPlace,EventDate,TicketsCount,GroupOrArtistName,HowToGetTo,HeadLiner")] OpenAirConcert concert)
        {
            if (!ModelState.IsValid)
            {
                return View(concert);
            }
            _service.Update(id, concert);
            return RedirectToAction(nameof(Index));
        }
    }
}
