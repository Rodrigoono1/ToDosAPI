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
    public class CategoriesController : ControllerBase
    {
        protected readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Categories
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDTO category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                Description = category.Description
            };
            _service.Save(newCategory);
            return Created();
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] CategoryDTO category)
        {
            var categoryUpdate = new Category
            {
                Name = category.Name,
                Description = category.Description
            };
            _service.Update(categoryUpdate, id);
            return NoContent();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
