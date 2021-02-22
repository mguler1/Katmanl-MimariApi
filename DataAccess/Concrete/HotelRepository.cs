using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
 public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        } 

        public void Delete(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletehotel = GetHotelById(id);
                hotelDbContext.Hotels.Remove(deletehotel);
                hotelDbContext.SaveChanges();
         
            }
        }

        public List<Hotel> GetAllHotels()
        {
            using (var hotelDbContext=new HotelDbContext())
            {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                return hotel;
            }
        }
    }
}
