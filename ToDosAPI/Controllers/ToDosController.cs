using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDosAPI.Data;
using ToDosAPI.Models;
using ToDosAPI.Services;

namespace ToDosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDosController(IToDoService service)
        {
            _service = service;
        }

        // GET: api/ToDos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        // POST: api/ToDos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] ToDo toDo)
        {
            _service.Save(toDo);
            

            return NoContent();
        }

        // PUT: api/ToDos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }

            _service.Update(toDo, id);
            return NoContent();
        }

        // DELETE: api/ToDos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
