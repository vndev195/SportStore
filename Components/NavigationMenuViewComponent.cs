using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Components
{
    [ViewComponent]
     public class NavigationMenuViewComponent : ViewComponent {
        private IStoreRepository  repository;
        public NavigationMenuViewComponent(IStoreRepository repo) {
            repository = repo;
        }
        public IViewComponentResult Invoke() {
            ViewBag.Category = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
        //public string Invoke() => "Hello world";
    }
}
