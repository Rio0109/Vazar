using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vazar.Data;
using Vazar.Data.model;

namespace Vazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public UsersController(ApplicationDbContext context)
        {
            _database = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var users = _database.Users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            // Ensure the Id is ignored
            user.Id = 0;

            // Provjera postoji li već korisnik s istim emailom
            var existingUser = _database.Users.SingleOrDefault(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return Conflict("Email already exists");  // Vraća 409 Conflict
            }

            _database.Users.Add(user);
            _database.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var numberOfDeletedRows = _database.Users
             .Where(user => user.Id == id)
             .ExecuteDelete();

            // If the return value is 0 means we didn't deleted any user
            if (numberOfDeletedRows == 0)
            {
                return NotFound();
            }

            return NoContent(); // Vratite 204 No Content status, jer se korisnik uspješno obrisao
        }
    }
}
