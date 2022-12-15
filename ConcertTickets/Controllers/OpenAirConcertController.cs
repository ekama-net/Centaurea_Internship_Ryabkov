using Microsoft.AspNetCore.Mvc;

namespace ConcertTickets.Controllers
{
    public class OpenAirConcertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
