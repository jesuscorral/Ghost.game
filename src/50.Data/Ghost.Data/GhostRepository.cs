using Ghost.Data.Interface;
using Ghost.Model.Ghost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// Implementation of the <see cref="IGhostRepository.GetWordsAsync(string)"/> method.
        /// </summary>
        /// <param name="startingWord"></param>
        /// <returns>List of words</returns>
        public async Task<IEnumerable<Word>> GetWordsAsync(string startingWord)
        {
            return await context.Words.Where(x => x.WordValue.StartsWith(startingWord)).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
