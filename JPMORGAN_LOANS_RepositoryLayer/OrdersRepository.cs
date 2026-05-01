using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using JPMORGAN_LOANS_BusinessEntities.MidlandModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_RepositoryLayer
{
    public class OrdersRepository : IOrdersRepository
    {
        #region Constructor Injection for DbContext class
        private readonly MidlandContext _context;

        public OrdersRepository(MidlandContext context)
        {
            _context = context;
        }
        #endregion

        #region AddOrder

        public async Task<int> AddOrder(Order orderdetail)
        {
            await _context.Orders.AddAsync(orderdetail);//add the record by using addasync
            _context.SaveChanges();//it will commit/save the data perminently in table
            return 1;
        }
        #endregion

        #region DeleteOrderById
        public async Task<bool> DeleteOrderById(int orderid)
        {
            var result = await _context.Orders.Where(a => a.Orderid == orderid).FirstOrDefaultAsync();
            if (result != null)
            {
                _context.Orders.Remove(result);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region GetOrderById

        public async Task<Order> GetOrderById(int orderid)
        {
            var rm = await _context.Orders.Where(e => e.Orderid == orderid).FirstOrDefaultAsync();

            if (rm == null)
                return null;
            else
                return rm;
        }
        #endregion

        #region GetOrders

        public async Task<List<Order>> GetOrders()
        {
            var result = _context.Orders.ToList();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region UpdateOrder

        public async Task<bool> UpdateOrder(Order orderdetail)
        {
            _context.Update(orderdetail);
            await _context.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
