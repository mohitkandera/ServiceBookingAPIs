using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceBookingAPI.Data;
using ServiceBookingAPI.Models;

namespace ServiceBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GettAllCategoriesById(int Id)
        {
            var categories = await _context.Categories.ToListAsync();

            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategories(Categories category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategories(int id, Categories  Categories)
        {
            if(id != Categories.Id)
            {
                return BadRequest();
            }
            _context.Categories.Update(Categories);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategories(int Id)
        {
            var categories = await _context.Categories.FindAsync();

           if(categories == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categories);
            await _context.SaveChangesAsync();


            return Ok("Categories deleted Successfullly");

        }
    }



    }

