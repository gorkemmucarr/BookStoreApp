using Entities.Dtos;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contract;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IServiceManager _manager;

        public BookController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index(BookRequestParameters bookRequestParameters)
        {
            var books = _manager.BookService.GetAllBooksWithDetails(bookRequestParameters);
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    books = books.Where(p => p.BookName.ToLower().Contains(searchString.ToLower())).ToList();
            //}
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _manager.BookService.GetOneBook(id);
            return View(book);
        }
        

        //public IActionResult Create()
        //{
        //    var categories = _manager.CategoryService.GetAllCategories();
        //    ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName"); 
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(BookDtoForCreate bookDtoForCreate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _manager.BookService.Create(bookDtoForCreate);
        //        return RedirectToAction("Index", bookDtoForCreate);
        //    }
        //    return View();
        //}

        //public IActionResult Delete(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _manager.BookService.Delete(id);
        //        return RedirectToAction("Index", id);
        //    }
        //    return View();
        //}

        //public IActionResult Update(int id)
        //{
        //    var book = _manager.BookService.GetOneBook(id);
        //    return View(book);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(BookDtoForUpdate bookDtoForUpdate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _manager.BookService.Update(bookDtoForUpdate);
        //        return RedirectToAction("Index", bookDtoForUpdate);
        //    }
        //    return View();
        //}
    }
}
