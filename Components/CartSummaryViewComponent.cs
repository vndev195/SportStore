using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
namespace SportStore.Components {
    public class CartSummaryViewComponent : ViewComponent {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService) {
            cart = cartService;
        }
        public IViewComponentResult Invoke() {
            return View(cart);
        }
    }
}