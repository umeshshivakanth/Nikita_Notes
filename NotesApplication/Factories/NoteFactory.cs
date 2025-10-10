using NotesApplication.Models;

namespace NotesApplication.Factories
{
    public class NoteFactory
    {

        public static Note Create(string title, string description, PriorityLevel? priority = null)
        {
            return new Note
            {
                Title = title,
                Description = description,
                Priority = priority ?? PriorityLevel.Medium,
                CreatedAt = DateTime.Now
            };
        }
    }
}
