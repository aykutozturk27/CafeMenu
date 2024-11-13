using CafeMenu.Business.Abstract;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeMenu.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var categoryList = _categoryService.GetAll();
            foreach (var category in categoryList.Data.Categories)
            {
                category.ParentCategoryName = category.ParentCategoryId.Value > 0 ? _categoryService.GetById(category.ParentCategoryId.Value).Data.CategoryName : "";
            }
            return Json(categoryList.Data);
        }

        public IActionResult Add()
        {
            var categoryList = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categoryList.Data.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddDto categoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryService.Add(categoryAddDto);
                return RedirectToAction("Index");
            }

            var categoryList = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categoryList.Data.Categories, "CategoryId", "CategoryName");
            return View(categoryAddDto);
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            var result = _categoryService.Update(categoryUpdateDto);
            return Json(result.Message);
        }

        [HttpPost]
        public IActionResult Delete(CategoryDeleteDto categoryDeleteDto)
        {
            var result = _categoryService.Delete(categoryDeleteDto);
            return Json(result.Message);
        }
    }
}
