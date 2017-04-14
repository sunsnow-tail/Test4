using System.Collections.Generic;
using System.Web.Mvc;
using Domain;
using System.Linq;

namespace WebUI.Controllers
{

    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo) {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null, bool horizontalLayout = false)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);

            string viewName = horizontalLayout ? "MenuHorizontal" : "Menu";
            return PartialView(viewName, categories);

        }
    }
}