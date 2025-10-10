using NotesApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace NotesApplication.ViewModel
{
    public class NoteViewModel
    {
       
            public int Id { get; set; }

            [Required(ErrorMessage = "Title is required")]
            [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
            public string Title { get; set; } = string.Empty;

            [Required(ErrorMessage = "Description is required")]
            [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
            public string Description { get; set; } = string.Empty;

            [Required(ErrorMessage = "Priority is required")]
            public PriorityLevel Priority { get; set; }

            public DateTime CreatedAt { get; set; }
        
    }
}
