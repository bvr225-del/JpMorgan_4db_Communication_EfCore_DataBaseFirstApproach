using JPMORGAN_LOANS_BusinessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_BusinessEntities.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDto>> GetRestaurants();
        Task<RestaurantDto> GetRestaurantById(int Id);
        Task<int> AddRestaurants(RestaurantDto resdetail);
        Task<bool> DeleteRestaurantById(int Id);
        Task<bool> UpdateRestaurant(RestaurantDto resdetail);

    }
}
