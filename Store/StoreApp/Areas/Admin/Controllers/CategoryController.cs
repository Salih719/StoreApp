using Entitites.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {   
            var model = _manager.CategoryService.GetAllCategories(false);
            return View(model);
        }

        public IActionResult Create()
        {
            TempData["info"] = "Please fill the form.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CategoryDtoForInsertion categoryDto)
        {
            if(ModelState.IsValid)
            {
                _manager.CategoryService.CreateCategory(categoryDto);
                TempData["success"] = $"{categoryDto.CategoryName} has been created.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id)
        {
            var model = _manager.CategoryService.GetOneCategoryForUpdate(id, false);
            ViewData["Title"] = model?.CategoryName;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] CategoryDtoForUpdate categoryDto)
        {
            if(ModelState.IsValid)
            {
                _manager.CategoryService.UpdateOneCategory(categoryDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.CategoryService.DeleteOneCategory(id);
            TempData["danger"] = "The Category has been removed.";
            return RedirectToAction("Index");
        }

    }
}