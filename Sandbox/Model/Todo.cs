using System.Text.Json.Serialization;

namespace Model
{
    public class Todo
    {
        public int TaskId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
