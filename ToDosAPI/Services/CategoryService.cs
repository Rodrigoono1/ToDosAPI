using Microsoft.AspNetCore.Http.HttpResults;
using ToDosAPI.Data;
using ToDosAPI.Models;

namespace ToDosAPI.Services
{
    public class CategoryService:ICategoryService
    {
        ApiContext _context;
        public CategoryService(ApiContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Get()
        {
            return _context.Categories;
        }
        public async Task Save(Category category)
        {
            category.Id = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category,Guid id)
        {
            var existingCategory = _context.Categories.Find(id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;

                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
    public interface ICategoryService
    {
        IEnumerable<Category> Get();
        Task Save(Category category);
        Task Update(Category category, Guid id);
        Task Delete(Guid id);
    }
}
