using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;

namespace BookStoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        private readonly IServiceManager _manager;

        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(string searchString)
        {
            ViewData["Title"] = "Books";
            var books = _manager.BookService.GetAllBook();
            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(p => p.BookName.ToLower()
                .Contains(searchString.ToLower())).ToList();
            }
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _manager.BookService.GetOneBook(id);
            ViewData["Title"] = book?.BookName;
            return View(book);
        }

        public IActionResult Update(int id)
        {
            var book = _manager.BookService.GetOneBook(id);
            ViewData["Title"] = book?.BookName;
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BookDtoForUpdate bookDtoForUpdate,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                bookDtoForUpdate.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.BookService.Update(bookDtoForUpdate);
                return RedirectToAction("Index", bookDtoForUpdate);
            }
            return View();
        }

        public IActionResult Create()
        {
            var categories = _manager.CategoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] BookDtoForCreate bookDtoForCreate,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                bookDtoForCreate.ImageUrl = String.Concat("/images/", file.FileName);
                _manager.BookService.Create(bookDtoForCreate);
                TempData["success"] = $"{bookDtoForCreate.BookName} has been created";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _manager.BookService.Delete(id);
                TempData["danger"] = $"Book has been deleted";
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
