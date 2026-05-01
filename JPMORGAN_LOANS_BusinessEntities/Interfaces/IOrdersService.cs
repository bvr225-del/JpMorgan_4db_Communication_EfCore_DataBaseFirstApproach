using JPMORGAN_LOANS_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_BusinessEntities.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrderDto>> GetOrders();
        Task<OrderDto> GetOrderById(int orderid);
        Task<int> AddOrder(OrderDto orderdetail);
        Task<bool> DeleteOrderById(int orderid);
        Task<bool> UpdateOrder(OrderDto orderdetail);

    }
}
