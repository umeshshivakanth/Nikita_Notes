namespace NotesApplication.Models
{ public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
    public class Note
    {

        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }

        public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
