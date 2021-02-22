using Business.Abstract;
using Business.Concrete;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController()
        {
            _hotelService = new HotelManager();
        }
        [HttpGet]
        public List<Hotel>Get()
        {
            return _hotelService.GetAllHotels();
        }
        [HttpGet("{id}")]
        public Hotel  Get(int id)
        {
            return _hotelService.GetHotelById(id);
        }
        [HttpPost]
        public Hotel Post([FromBody] Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }
        [HttpPut]
        public Hotel Put([FromBody] Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.Delete(id);
        }
    }
}
