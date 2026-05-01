using JPMORGAN_LOANS_BusinessEntities.RestaurantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPMORGAN_LOANS_BusinessEntities.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurants();
        Task<Restaurant> GetRestaurantById(int Id);
        Task<int> AddRestaurants(Restaurant resdetail);
        Task<bool> DeleteRestaurantById(int Id);
        Task<bool> UpdateRestaurant(Restaurant resdetail);

    }
}
