using Ghost.Data.Interface;
using Ghost.Model.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ghost.Data
{
    public class GhostRepository : BaseRepository, IGhostRepository
    {

        public GhostRepository(
            ILogger<GhostRepository> logger, 
            GhostDataContext context) 
            : base(logger, context)
        {
        }

        public async Task<IEnumerable<Word>> GetWordsAsync()
        {
            return await context.Words.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
