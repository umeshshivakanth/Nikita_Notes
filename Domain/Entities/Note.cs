using BasicNotesApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }       // Foreign key
        public Category Category { get; set; }
    }
}
