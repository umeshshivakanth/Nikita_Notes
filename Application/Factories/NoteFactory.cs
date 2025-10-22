using BasicNotesApp.Domain.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public class NoteFactory
    {
        public static Note Create(string title, string content, int categoryId, PriorityLevel priority = PriorityLevel.Medium)
        {
            return new Note
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                Priority = priority,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
