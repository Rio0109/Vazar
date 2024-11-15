using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

    }
}
