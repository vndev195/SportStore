using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
namespace SportStore.Controllers {
    public class OrderController : Controller {
        public ViewResult Checkout() => View(new Order());
    }
}