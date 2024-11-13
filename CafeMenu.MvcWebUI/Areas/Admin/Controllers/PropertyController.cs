using CafeMenu.Business.Abstract;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CafeMenu.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var propertyList = _propertyService.GetAll();
            return Json(propertyList.Data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PropertyAddDto propertyAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = _propertyService.Add(propertyAddDto);
                return RedirectToAction("Index");
            }
            return View(propertyAddDto);
        }

        public IActionResult Update(int propertyId)
        {
            var result = _propertyService.GetById(propertyId);
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Update(PropertyUpdateDto propertyUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = _propertyService.Update(propertyUpdateDto);
                return RedirectToAction("Index");
            }
            return View(propertyUpdateDto);
        }

        [HttpPost]
        public IActionResult Delete(PropertyDeleteDto propertyDeleteDto)
        {
            var result = _propertyService.Delete(propertyDeleteDto);
            return Json(result.Message);
        }
    }
}
