using CafeMenu.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeMenu.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var productList = _productService.GetAll();
            return Json(productList.Data);
        }
    }
}
