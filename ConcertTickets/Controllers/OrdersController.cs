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

        public async Task<IActionResult> Index()
        {
            string userId = "";

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, "");
            return View(orders);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

         //TODO: Make it better with react
        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _concertService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _concertService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";
            string userEmailAdress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAdress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
