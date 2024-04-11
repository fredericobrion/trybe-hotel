using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == booking.RoomId);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            if (room.Capacity < booking.GuestQuant)
            {
                throw new Exception("Guest quantity over room capacity");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            var bookingToCreate = new Booking
            {
                CheckIn = booking.CheckIn,
                CheckOut = booking.Checkout,
                GuestQuant = booking.GuestQuant,
                UserId = user.UserId,
                RoomId = booking.RoomId,
            };

            var bookingCreated = _context.Bookings.Add(bookingToCreate).Entity;
            _context.SaveChanges();

            var hotel = _context.Hotels.First(h => h.HotelId == room.HotelId);
            var city = _context.Cities.First(c => c.CityId == hotel.CityId);

            var response = new BookingResponse
            {
                BookingId = bookingCreated.BookingId,
                CheckIn = booking.CheckIn,
                CheckOut = booking.Checkout,
                GuestQuant = booking.GuestQuant,
                Room = new RoomDto
                {
                    Capacity = room.Capacity,
                    RoomId = room.RoomId,
                    Name = room.Name,
                    Image = room.Image,
                    Hotel = new HotelDto
                    {
                        Address = hotel.Address,
                        CityId = hotel.CityId,
                        CityName = city.Name,
                        HotelId = hotel.HotelId,
                        Name = hotel.Name,
                        State = city.State
                    }
                }
            };

            return response;
        }

        public BookingResponse GetBooking(int bookingId, string email)
        {
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking == null) throw new Exception("Booking not found");

            var user = _context.Users.First(u => u.UserId == booking.UserId);
            if (user.Email != email) throw new UnauthorizedAccessException("Unauthorized");

            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == booking.RoomId);
            var hotel = _context.Hotels.First(h => h.HotelId == room.HotelId);
            var city = _context.Cities.First(c => c.CityId == hotel.CityId);

            var response = new BookingResponse
            {
                BookingId = booking.BookingId,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                GuestQuant = booking.GuestQuant,
                Room = new RoomDto
                {
                    Capacity = room.Capacity,
                    RoomId = room.RoomId,
                    Name = room.Name,
                    Image = room.Image,
                    Hotel = new HotelDto
                    {
                        Address = hotel.Address,
                        CityId = hotel.CityId,
                        CityName = city.Name,
                        HotelId = hotel.HotelId,
                        Name = hotel.Name,
                        State = city.State
                    }
                }
            };

            return response;
        }

        public Room GetRoomById(int RoomId)
        {
            throw new NotImplementedException();
        }

    }

}