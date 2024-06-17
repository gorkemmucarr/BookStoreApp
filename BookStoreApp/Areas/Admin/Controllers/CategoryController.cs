using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;
using System.Data;

namespace BookStoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var categories = _manager.CategoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            var categories = _manager.CategoryService.GetAllCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryDtoForCreate categoryDtoForCreate)
        {
            if (ModelState.IsValid)
            {
                _manager.CategoryService.CreateCategory(categoryDtoForCreate);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
