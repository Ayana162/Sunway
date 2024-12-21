using HotelAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/hotels")]
    public class HotelController : Controller
    {
        private HotelDAL _hotelDAL;
        public HotelController(HotelDAL hotelDAL)
        {
            _hotelDAL = hotelDAL;
        }

        [HttpGet]
        public IActionResult GetHotels()
        {
            try
            {
                var hotels = _hotelDAL.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var hotel = _hotelDAL.GetHotelById(id);
                if (hotel == null)
                {
                    return NotFound(new { message = "Hotel does not exist" });
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }

        }

    }
}
