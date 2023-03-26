using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IorderRepository : IRepository<Order, long>
    {
        Task<IEnumerable<Order>> GetAllOrder();

    }
}
