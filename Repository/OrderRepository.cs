using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Lines)   // order'lardan Line'lara
            .ThenInclude(cl => cl.Book) // Line'lardan Cartline'lara
            .OrderBy(o => o.Shipped)
            .ThenByDescending(o => o.OrderId);

        public int NumberOfInProcess =>
            _context.Orders.Count(p => p.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = GetOneOrder(id);
            if (order is null)
            {
                throw new Exception("System have an error");
            }
            else
            {
                order.Shipped = true;
            }
        }

        public Order GetOneOrder(int id)
        {
            var order = FindByCondition(p => p.OrderId.Equals(id));
            return order;
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(p => p.Book));
            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }


        }
    }
}
