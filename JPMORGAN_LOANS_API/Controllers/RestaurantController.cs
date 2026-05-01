using JPMORGAN_LOANS_BusinessEntities.Dtos;
using JPMORGAN_LOANS_BusinessEntities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JPMORGAN_LOANS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        #region Constructor Injection for IRestaurantService
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        #endregion

        #region [HttpPost]
        [HttpPost]
        [Route("AddRestaurants")]
        public async Task<IActionResult> Post([FromBody] RestaurantDto resdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var resData = await _restaurantService.AddRestaurants(resdto);
                    return StatusCode(StatusCodes.Status201Created, resData);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        #endregion

        #region [HttpDelete]
        [HttpDelete]
        [Route("DeleteRestaurantById/{Id}")]
        public async Task<IActionResult> delete(int Id)
        {
            if (Id < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var resData = await _restaurantService.DeleteRestaurantById(Id);

                if (resData == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "orderData not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        #endregion

        #region [HttpGet]
        [HttpGet]
        [Route("GetRestaurants")]
        public async Task<IActionResult> GetRestaurant()
        {
            try
            {
                var resdata = await _restaurantService.GetRestaurants();
                if (resdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "orderData not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, resdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        #endregion

        #region [HttpGetById]
        [HttpGet]
        [Route("GetRestaurantById/{Id}")]
        public async Task<IActionResult> GetRestaurantById(int Id)
        {
            if (Id < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var resdata = await _restaurantService.GetRestaurantById(Id);
                return StatusCode(StatusCodes.Status200OK, resdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        #endregion

        #region [HttpPut]
        [HttpPut]
        [Route("UpdateRestaurant")]
        public async Task<IActionResult> put([FromBody] RestaurantDto resdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var resData = await _restaurantService.UpdateRestaurant(resdto);
                    return StatusCode(StatusCodes.Status200OK, resData);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        #endregion

    }
}
