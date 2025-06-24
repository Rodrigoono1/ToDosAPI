using System.Text.Json.Serialization;

namespace ToDosAPI.Models
{
    public class Category
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [JsonIgnore]
        public virtual List<ToDo>? ToDos { get; set; }
    }
}
