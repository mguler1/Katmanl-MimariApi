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
        public IActionResult Get()
        {
            var hotels= _hotelService.GetAllHotels();
            return Ok(hotels);//200 döndür body kısmına Hoteli ekle
        }
            
        [HttpGet("{id}")]
        public IActionResult  Get(int id)
        {
            var hotel= _hotelService.GetHotelById(id);
            if (hotel!=null)
            {
                return Ok(hotel);
            }
            return NotFound(); //404
        }
        [HttpPost]
        public IActionResult Post([FromBody] Hotel hotel)
        {
            if (ModelState.IsValid)//validasyon kontrolü
            {
                var createHotel= _hotelService.CreateHotel(hotel);
                return CreatedAtAction("Get", new { id = createHotel.Id }, createHotel);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.Delete(id);
                return Ok();
            }
            return NotFound();
          
        }
    }
}
