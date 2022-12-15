using Microsoft.AspNetCore.Mvc;

namespace ConcertTickets.Controllers
{
    public class ClassicalConcertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
