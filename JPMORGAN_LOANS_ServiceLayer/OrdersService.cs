using AutoMapper;
using JPMORGAN_LOANS_BusinessEntities.Dtos;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using JPMORGAN_LOANS_BusinessEntities.MidlandModels;
using JPMORGAN_LOANS_RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_ServiceLayer
{
    public class OrdersService : IOrdersService
    {
        #region Constructor Injection for IOrdersRepository
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;


        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            this._mapper = mapper;
        }
        #endregion

        #region AddOrder

        public async Task<int> AddOrder(OrderDto orderdetail)
        {
            Order order = new Order();
            _mapper.Map(orderdetail, order);
            var res = await _ordersRepository.AddOrder(order);
            return res;
        }
        #endregion

        #region DeleteOrderById

        public async Task<bool> DeleteOrderById(int orderid)
        {
            await _ordersRepository.DeleteOrderById(orderid);
            return true;
        }
        #endregion

        #region GetOrderById

        public async Task<OrderDto> GetOrderById(int orderid)
        {
            var res = await _ordersRepository.GetOrderById(orderid);
            return _mapper.Map<OrderDto>(res);
        }
        #endregion

        #region GetOrders

        public async Task<List<OrderDto>> GetOrders()
        {
            var res = await _ordersRepository.GetOrders();
            return _mapper.Map<List<OrderDto>>(res);
        }
        #endregion

        #region UpdateOrder

        public async Task<bool> UpdateOrder(OrderDto orderdetail)
        {
            Order obj = new Order();
            _mapper.Map(orderdetail, obj);
            await _ordersRepository.UpdateOrder(obj);
            return true;
        }
        #endregion
    }
}
