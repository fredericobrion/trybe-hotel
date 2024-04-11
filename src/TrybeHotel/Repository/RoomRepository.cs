using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            var rooms = _context.Rooms
                .Where(r => r.HotelId == HotelId)
                .Select(r => new RoomDto
                {
                    RoomId = r.RoomId,
                    Name = r.Name,
                    Capacity = r.Capacity,
                    Image = r.Image,
                    Hotel = new HotelDto
                    {
                        Name = r.Hotel.Name,
                        Address = r.Hotel.Address,
                        CityId = r.Hotel.CityId,
                        HotelId = r.Hotel.HotelId,
                        CityName = r.Hotel.City.Name,
                        State = r.Hotel.City.State
                    }
                });

            return rooms;


        }

        public RoomDto AddRoom(Room room)
        {
            var hotelExistsInDb = _context.Hotels.First(h => h.HotelId == room.HotelId);
            if (hotelExistsInDb == null) throw new Exception("Hotel not found in Database");

            _context.Rooms.Add(room);
            _context.SaveChanges();

            var city = _context.Cities.First(c => c.CityId == hotelExistsInDb.CityId);

            return new RoomDto
            {
                Name = room.Name,
                Capacity = room.Capacity,
                Image = room.Image,
                RoomId = room.RoomId,
                Hotel = new HotelDto
                {
                    Address = hotelExistsInDb.Address,
                    CityId = hotelExistsInDb.CityId,
                    HotelId = hotelExistsInDb.HotelId,
                    Name = hotelExistsInDb.Name,
                    CityName = city.Name,
                    State = city.State
                }
            };
        }

        public void DeleteRoom(int RoomId)
        {
            var room = _context.Rooms.First(r => r.RoomId == RoomId);

            if (room == null) throw new Exception("Room not found in Database");

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}