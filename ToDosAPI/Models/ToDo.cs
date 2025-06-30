namespace ToDosAPI.Models
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority ToDoPriority { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Category Category { get; set; }
        public string Summary { get; set; }
    }
    public class ToDoDTO
    {
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority ToDoPriority { get; set; }
        public DateTime DateCreated { get; set; }
        public string Summary { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
