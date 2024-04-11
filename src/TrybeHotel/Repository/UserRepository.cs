using TrybeHotel.Models;
using TrybeHotel.Dto;
using TrybeHotel.Exceptions;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == login.Email);
            if (userInDb == null || userInDb.Password != login.Password)
            {
                throw new UnauthorizedAccessException("Incorrect e-mail or password");
            }
            return new UserDto
            {
                Email = userInDb.Email,
                Name = userInDb.Name,
                UserId = userInDb.UserId,
                UserType = userInDb.UserType,
            };
        }
        public UserDto Add(UserDtoInsert user)
        {
            var userInDb = _context.Users.Add(new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client"
            }).Entity;
            _context.SaveChanges();

            return new UserDto
            {
                Email = userInDb.Email,
                Name = userInDb.Name,
                UserId = userInDb.UserId,
                UserType = userInDb.UserType,
            };
        }

        public UserDto GetUserByEmail(string userEmail)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user != null)
            {
                return new UserDto
                {
                    Email = user.Email,
                    Name = user.Name,
                    UserId = user.UserId,
                    UserType = user.UserType,
                };
            }

            return null;
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var users = _context.Users.Select(u => new UserDto
            {
                UserId = u.UserId,
                Email = u.Email,
                Name = u.Name,
                UserType = u.UserType
            });

            return users;
        }

    }
}