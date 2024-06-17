using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthService _authService;
        private readonly IOrderService _orderService;
        public ServiceManager(IBookService bookService,
            ICategoryService categoryService,
            IAuthService authService,
            IOrderService orderService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _authService = authService;
            _orderService = orderService;
        }
        public IBookService BookService => _bookService;

        public ICategoryService CategoryService => _categoryService;

        public IAuthService AuthService => _authService;

        public IOrderService OrderService => _orderService;
    }
}
