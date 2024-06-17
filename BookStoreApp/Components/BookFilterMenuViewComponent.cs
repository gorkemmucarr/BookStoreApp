using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.Components
{
    public class BookFilterMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
