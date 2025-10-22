using BasicNotesApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BasicNotesApp.Web.ViewModel
{
    public class NoteViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public PriorityLevel Priority { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }
    }
}
