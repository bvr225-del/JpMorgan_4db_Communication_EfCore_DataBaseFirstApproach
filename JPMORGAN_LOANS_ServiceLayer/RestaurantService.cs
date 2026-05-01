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
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }
        #endregion

        #region AddRestaurants
        public async Task<int> AddRestaurants(RestaurantDto resdetail)
        {
            Restaurant res = new Restaurant();
            res.Id = resdetail.Id;
            res.RestaurantName = resdetail.RestaurantName;
            res.RestaurantLocation = resdetail.RestaurantLocation;
            res.CreationDate = resdetail.CreationDate;
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
            RestaurantDto resdto = new RestaurantDto();
            resdto.Id = res.Id;
            resdto.RestaurantName = res.RestaurantName;
            resdto.RestaurantLocation = res.RestaurantLocation;
            resdto.CreationDate = res.CreationDate;
            return resdto;

        }
        #endregion

        #region GetRestaurants

        public async Task<List<RestaurantDto>> GetRestaurants()
        {
            List<RestaurantDto> listresdto = new List<RestaurantDto>();
            var res = await _restaurantRepository.GetRestaurants();
            foreach (Restaurant restaurant in res)
            {
                RestaurantDto resDto = new RestaurantDto();
                resDto.Id = restaurant.Id;
                resDto.RestaurantName = restaurant.RestaurantName;
                resDto.RestaurantLocation = restaurant.RestaurantLocation;
                resDto.CreationDate = restaurant.CreationDate;
                listresdto.Add(resDto);//Add the orders to list here

            }
            return listresdto;

        }
        #endregion

        #region UpdateRestaurant

        public async Task<bool> UpdateRestaurant(RestaurantDto resdetail)
        {
            Restaurant obj = new Restaurant();
            obj.Id = resdetail.Id;
            obj.RestaurantName = resdetail.RestaurantName;
            obj.RestaurantLocation = resdetail.RestaurantLocation;
            obj.CreationDate = resdetail.CreationDate;
            await _restaurantRepository.UpdateRestaurant(obj);
            return true;


        }
        #endregion
    }
}
