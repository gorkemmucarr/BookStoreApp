using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contract;

namespace BookStoreApp.Pages
{
    public class CartModel : PageModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        private readonly IServiceManager _manager;

        public CartModel(IServiceManager manager,Cart cart)
        {
            _manager = manager;
            Cart = cart;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId,string returnUrl)
        {
            Book? book = _manager.BookService.GetOneBook(bookId);
            if (book is not null)
            {
                Cart.AddItem(book, 1);
            }
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(p => p.Book.BookId.Equals(id)).Book);
            return Page();
        }
    }
}
