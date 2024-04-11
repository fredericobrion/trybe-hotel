using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            var hotels = _context.Hotels.Select(h => new HotelDto
            {
                HotelId = h.HotelId,
                Name = h.Name,
                Address = h.Address,
                CityId = h.CityId,
                CityName = h.City.Name,
                State = h.City.State
            }).ToList();
            return hotels;
        }

        public HotelDto AddHotel(Hotel hotel)
        {
            var cityExistInDb = _context.Cities.FirstOrDefault(c => c.CityId == hotel.CityId);
            if (cityExistInDb == null) throw new Exception("City not found in Database");

            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            var hotelInDb = _context.Hotels.First(h => h.HotelId == hotel.HotelId);
            var response = new HotelDto
            {
                Name = hotel.Name,
                HotelId = hotel.HotelId,
                Address = hotel.Address,
                CityId = hotelInDb.CityId,
                CityName = hotelInDb.City.Name,
                State = hotelInDb.City.State
            };

            return response;
        }
    }
}