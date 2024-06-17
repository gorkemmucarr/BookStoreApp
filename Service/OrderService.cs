using Entities;
using Entities.Models;
using Repositories.Contract;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _manager;

        public OrderService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IQueryable<Order> Orders => _manager.OrderRepository.Orders;

        public int NumberOfInProcess => _manager.OrderRepository.NumberOfInProcess;

        public void Complete(int id)
        {
             _manager.OrderRepository.Complete(id);
            _manager.Save();
        }

        public Order GetOneOrder(int id)
        {
            return _manager.OrderRepository.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _manager.OrderRepository.SaveOrder(order);
            _manager.Save();
        }
    }
}
