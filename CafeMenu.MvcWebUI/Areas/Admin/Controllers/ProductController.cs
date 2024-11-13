using Microsoft.AspNetCore.Mvc;

namespace CafeMenu.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
