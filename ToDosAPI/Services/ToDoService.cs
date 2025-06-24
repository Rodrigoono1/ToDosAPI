using ToDosAPI.Models;
using ToDosAPI.Data;
namespace ToDosAPI.Services
{
    public class ToDoService:IToDoService
    {
        ApiContext _context;
        public ToDoService(ApiContext context)
        {
            _context = context;
        }
        public IEnumerable<ToDo> Get()
        {
            return _context.ToDos;
        }
        public async Task Save(ToDo todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
        }
        public async Task Update(ToDo todo, Guid id)
        {
            var existingToDo = _context.ToDos.Find(id);
            if (existingToDo != null)
            {
                existingToDo.Title = todo.Title;
                existingToDo.Description = todo.Description;
                existingToDo.CategoryId = todo.CategoryId;
                existingToDo.ToDoPriority = todo.ToDoPriority;
                existingToDo.DateCreated = todo.DateCreated;
                await _context.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo != null)
            {
                _context.ToDos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }
    }
    public interface IToDoService
    {
        // Define methods for ToDoService here, e.g.:
        IEnumerable<ToDo> Get();
        Task Save(ToDo todo);
        Task Update(ToDo todo, Guid id);
        Task Delete(Guid id);
    }
}
