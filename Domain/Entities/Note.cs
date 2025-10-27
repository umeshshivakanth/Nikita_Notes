
using System;

namespace Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
