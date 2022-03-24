using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _repository;
        public int PageSize = 4;
        public HomeController(IStoreRepository repository)
        {
            _repository = repository;
        }
        //public IActionResult Index(int productPage = 1)
        //{
        //    return View(_repository.Products.OrderBy(x => x.ProductId).Skip((productPage - 1) * PageSize).Take(PageSize));
        //}

        public IActionResult Index(string? category)
        {
            return View(_repository.Products.Where(x=>x.Category == category || category == null));
        }

    }
}
