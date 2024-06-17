using Microsoft.AspNetCore.Mvc;
using Services.Contract;

namespace BookStoreApp.Components
{
    public class BookSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public BookSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager.BookService.GetAllBook().Count().ToString();
        }
    }
}
