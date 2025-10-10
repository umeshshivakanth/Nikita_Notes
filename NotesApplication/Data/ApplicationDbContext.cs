using Microsoft.EntityFrameworkCore;

namespace NotesApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<NotesApplication.Models.Note> Notes { get; set; }

    }
}
