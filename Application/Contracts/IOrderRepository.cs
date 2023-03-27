using Domain.Entities;
using Reposatory.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IOrderRepository : IRepository<Order, long>
    {
        Task<IEnumerable<Order>> GetAllOrder();
        Task<Order> AddOreder(OrderDTO orderDTO);

    }
}
