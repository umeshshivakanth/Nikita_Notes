using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class NotesDbContext :DbContext
    {

        public NotesDbContext(DbContextOptions<NotesDbContext> options)
           : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships (Category -> Notes) explicitly
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Notes)
                .WithOne(n => n.Category)
                .HasForeignKey(n => n.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
