using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using TrybeHotel.Exceptions;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("user")]

    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Policy = "Admin")]
        public IActionResult GetUsers()
        {
            try
            {
                var response = _repository.GetUsers();
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal error");
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
            try
            {
                var userWithEmailInDb = _repository.GetUserByEmail(user.Email);
                if (userWithEmailInDb != null)
                {
                    throw new EmailAlreadyExistsException("User email already exists");
                }
                var response = _repository.Add(user);
                return Created("", response);
            }
            catch (EmailAlreadyExistsException e)
            {
                return Conflict(new { message = e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}