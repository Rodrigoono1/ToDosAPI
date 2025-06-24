using Microsoft.EntityFrameworkCore;
using System.Threading;
using ToDosAPI.Models;

namespace ToDosAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("Category");
                category.HasKey(c => c.Id);
                category.Property(c => c.Name).IsRequired().HasMaxLength(100);
                category.Property(c => c.Description).IsRequired(false);
            });
            modelBuilder.Entity<ToDo>(todo =>
            {
                todo.ToTable("ToDo");
                todo.HasKey(p => p.Id);
                todo.HasOne(p => p.Category).WithMany(p => p.ToDos).HasForeignKey(p => p.CategoryId);
                todo.Property(p => p.Title).IsRequired().HasMaxLength(200);
                todo.Property(p => p.Description).IsRequired(false);
                todo.Property(p => p.ToDoPriority);
                todo.Property(p => p.DateCreated);
                todo.Ignore(p => p.Summary);
            });
        }
    }
}