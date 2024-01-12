using Microsoft.EntityFrameworkCore;
using Contracts;

namespace NotesDAL.EF
{
    public class NoteDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public NoteDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = notes.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
