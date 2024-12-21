using HotelAPI.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HotelAPI.Services
{
    public class HotelDAL
    {
        private string _hotelList;

        /// <summary>
        /// Access the data source from json file
        /// </summary>
        /// <param name="environment"></param>
        public HotelDAL(IWebHostEnvironment environment)
        {
            _hotelList = Path.Combine(environment.ContentRootPath, "DataSource/hotels.json");
        }
        /// <summary>
        /// Get all hotels
        /// </summary>
        /// <returns></returns>
        public List<Hotel> GetAllHotels()
        {
            try
            {
                var hotelJson = File.ReadAllText(_hotelList);
                return JsonConvert.DeserializeObject<List<Hotel>>(hotelJson);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
        /// <summary>
        /// Get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hotel GetHotelById(int id)
        {
            try
            {
                var hotels = GetAllHotels();
                return hotels.FirstOrDefault(h => h.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }
    }
}
