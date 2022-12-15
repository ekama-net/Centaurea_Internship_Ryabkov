using Microsoft.AspNetCore.Mvc;

namespace ConcertTickets.Controllers
{
    public class PartyConcertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
