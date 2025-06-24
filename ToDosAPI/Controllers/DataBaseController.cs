using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDosAPI.Data;

namespace ToDosAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private readonly ApiContext _context;

        public DataBaseController(ApiContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        public IActionResult Get()
        {
            _context.Database.EnsureCreated();
            bool isCreated = _context.Database.IsInMemory();
            return Ok("Database created in memory: "+isCreated);
        }
    }
}
