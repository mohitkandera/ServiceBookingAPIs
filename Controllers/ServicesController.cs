using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceBookingAPI.Data;
using ServiceBookingAPI.Models;

namespace ServiceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var Services = await _context.Categories.ToListAsync();
            return Ok(Services);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllServicesById()
        {
            var services = await _context.Services.ToListAsync();

            if (services != null)
                return Ok(services);

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServices(Services service)
        {
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();

            return Ok(service);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateServcies(int id, Services service)
        {
            var Services = await _context.Services.FindAsync();

            if (id != service.Id)
            {
                return BadRequest();
            }
            _context.Services.Update(service);
            await _context.SaveChangesAsync();

            return Ok(service);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServices(int id )
        {
            var service = await _context.Services.FindAsync();

            if(service== null)
            {
                return BadRequest();
            }
             _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return Ok("Service Deleted Successfully");
        }

    }
    }

