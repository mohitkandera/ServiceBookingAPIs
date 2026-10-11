using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ServiceBookingAPI.Data;
using ServiceBookingAPI.Models;

namespace ServiceBookingAPI.Controllers
{
  

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        // Http : Api/Auth/test
        [HttpGet("test")]
        public IActionResult Get()
        {
            return Ok("Your Auth is working");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Users user)
        {
            // check if email already exist
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);

            if (existingUser != user)
            {
                return BadRequest(new
                {
                    message = "Email already Registered"
                });
            }
            //Default role

            if (string.IsNullOrEmpty(user.Role))
            {
                user.Role = "Customer";
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Register successfully",
                userId = user.Id,
                name = user.Name,
                email = user.Email,
                role = user.Role

            });
        }

        //  Login /  API
        [HttpPost("login")]
        public async Task<IActionResult> Login(Users loginUser)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                x.Email == loginUser.Email &&
                x.Password == loginUser.Password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid EMail or Password"
                });
            }
            return Ok(new
            {
                message = "Login Successfull",
                name = user.Name,
                email = user.Email,
                role = user.Role
            });
        }
    }
}

 
