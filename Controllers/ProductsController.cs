using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vazar.Data;
using Vazar.Data.model;

namespace Vazar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public ProductsController(ApplicationDbContext context)
        {
            _database = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _database.Products.ToList();
            return Ok(products);
        }
    }
}