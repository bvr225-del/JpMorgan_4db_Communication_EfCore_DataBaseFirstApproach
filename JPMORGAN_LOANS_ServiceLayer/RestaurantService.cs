using AutoMapper;
using JPMORGAN_LOANS_BusinessEntities.Dtos;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using JPMORGAN_LOANS_BusinessEntities.RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_ServiceLayer
{
    public class RestaurantService : IRestaurantService
    {
        #region Constructor Injection for IRestaurantRepository
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            this._mapper = mapper;
        }
        #endregion

        #region AddRestaurants
        public async Task<int> AddRestaurants(RestaurantDto resdetail)
        {
            Restaurant res = new Restaurant();
            _mapper.Map(resdetail, res);
            var result = await _restaurantRepository.AddRestaurants(res);
            return 1;

        }
        #endregion

        #region DeleteRestaurantById

        public async Task<bool> DeleteRestaurantById(int Id)
        {
            await _restaurantRepository.DeleteRestaurantById(Id);
            return true;

        }
        #endregion

        #region GetRestaurantById

        public async Task<RestaurantDto> GetRestaurantById(int Id)
        {
            var res = await _restaurantRepository.GetRestaurantById(Id);
            return _mapper.Map<RestaurantDto>(res);

        }
        #endregion

        #region GetRestaurants

        public async Task<List<RestaurantDto>> GetRestaurants()
        {
            var res = await _restaurantRepository.GetRestaurants();
            return _mapper.Map<List<RestaurantDto>>(res);

        }
        #endregion

        #region UpdateRestaurant

        public async Task<bool> UpdateRestaurant(RestaurantDto resdetail)
        {
            Restaurant obj = new Restaurant();
            _mapper.Map(resdetail, obj);
            await _restaurantRepository.UpdateRestaurant(obj);
            return true;


        }
        #endregion
    }
}
