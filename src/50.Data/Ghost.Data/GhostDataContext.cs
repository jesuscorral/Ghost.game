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
    }
}