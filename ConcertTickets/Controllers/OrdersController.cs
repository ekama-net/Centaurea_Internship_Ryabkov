using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConcertTickets
{
    public class OrdersController : Controller
    {
        private readonly IConcertService _concertService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;

        public OrdersController(IConcertService concertService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _concertService = concertService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _concertService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
