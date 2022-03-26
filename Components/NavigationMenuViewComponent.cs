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
            //allows unstructured data to be passed to a view alongside the view model object
            ViewBag.Category = RouteData?.Values["category"];
            return View(repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
        //public string Invoke() => "Hello world";
    }
}
