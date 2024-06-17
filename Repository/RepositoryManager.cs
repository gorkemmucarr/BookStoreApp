using Repositories.Contract;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        public RepositoryManager(
            RepositoryContext context,
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository,
            IOrderRepository orderRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }
        public IBookRepository BookRepository => _bookRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
