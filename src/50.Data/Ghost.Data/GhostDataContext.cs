using Ghost.Model.Ghost;
using Microsoft.EntityFrameworkCore;

namespace Ghost.Data
{
    public class GhostDataContext : DbContext
    {
        public GhostDataContext(DbContextOptions<GhostDataContext> options) : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Word>().ToTable("Words");
            builder.Entity<Word>().HasKey(p => p.Id);
            builder.Entity<Word>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Word>().Property(p => p.WordValue).IsRequired().HasMaxLength(50);
        }

    }
}