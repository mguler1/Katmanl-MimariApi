using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IHotelService
    {
        List<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);
        Hotel CreateHotel(Hotel hotel);
        Hotel UpdateHotel(Hotel hotel);
        void Delete(int id);
    }
}
