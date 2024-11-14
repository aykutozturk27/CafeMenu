using CafeMenu.Business.Abstract;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeMenu.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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

        public IActionResult Add()
        {
            var categoryList = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categoryList.Data.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductAddDto productAddDto, IFormFile formFile)
        {
            if(ModelState.IsValid)
            {
                var result = _productService.Add(productAddDto, formFile);
                return RedirectToAction("Index");
            }

            var categoryList = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categoryList.Data.Categories, "CategoryId", "CategoryName");
            return View(productAddDto);
        }

        public IActionResult Update(int productId)
        {
            var categoryList = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categoryList.Data.Categories, "CategoryId", "CategoryName");
            var selectedProduct = _productService.GetById(productId);
            return View(selectedProduct.Data);
        }

        [HttpPost]
        public IActionResult Update(ProductUpdateDto productUpdateDto, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Update(productUpdateDto, formFile);
                return RedirectToAction("Index");
            }

            var categoryList = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categoryList.Data.Categories, "CategoryId", "CategoryName");
            return View(productUpdateDto);
        }

        [HttpPost]
        public IActionResult Delete(ProductDeleteDto productDeleteDto)
        {
            var result = _productService.Delete(productDeleteDto);
            return Json(result.Message);
        }
    }
}
