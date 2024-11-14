using CafeMenu.Business.Abstract;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeMenu.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductPropertyController : Controller
    {
        private readonly IProductPropertyService _productPropertyService;
        private readonly IProductService _productService;
        private readonly IPropertyService _propertyService;

        public ProductPropertyController(IProductPropertyService productPropertyService, IProductService productService, IPropertyService propertyService)
        {
            _productPropertyService = productPropertyService;
            _productService = productService;
            _propertyService = propertyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var productPropertyList = _productPropertyService.GetAll();
            return Json(productPropertyList.Data);
        }

        public IActionResult Add()
        {
            var productList = _productService.GetAll();
            ViewBag.Products = new SelectList(productList.Data.Products, "ProductId", "ProductName");

            var propertyList = _propertyService.GetAll();
            ViewBag.Properties = new SelectList(propertyList.Data.Properties, "PropertyId", "Key");

            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductPropertyAddDto productPropertyAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = _productPropertyService.Add(productPropertyAddDto);
                return RedirectToAction("Index");
            }

            var productList = _productService.GetAll();
            ViewBag.Products = new SelectList(productList.Data.Products, "ProductId", "ProductName");

            var propertyList = _propertyService.GetAll();
            ViewBag.Properties = new SelectList(propertyList.Data.Properties, "PropertyId", "Key");
            return View(productPropertyAddDto);
        }

        public IActionResult Update(int productPropertyId)
        {
            var productList = _productService.GetAll();
            ViewBag.Products = new SelectList(productList.Data.Products, "ProductId", "ProductName");

            var propertyList = _propertyService.GetAll();
            ViewBag.Properties = new SelectList(propertyList.Data.Properties, "PropertyId", "Key");

            var result = _productPropertyService.GetById(productPropertyId);
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Update(ProductPropertyUpdateDto productPropertyUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = _productPropertyService.Update(productPropertyUpdateDto);
                return RedirectToAction("Index", "ProductProperty");
            }

            var productList = _productService.GetAll();
            ViewBag.Products = new SelectList(productList.Data.Products, "ProductId", "ProductName");

            var propertyList = _propertyService.GetAll();
            ViewBag.Properties = new SelectList(propertyList.Data.Properties, "PropertyId", "Key");

            return View(productPropertyUpdateDto);
        }

        [HttpPost]
        public IActionResult Delete(ProductPropertyDeleteDto productPropertyDeleteDto)
        {
            var result = _productPropertyService.Delete(productPropertyDeleteDto);
            return Json(result.Message);
        }
    }
}
