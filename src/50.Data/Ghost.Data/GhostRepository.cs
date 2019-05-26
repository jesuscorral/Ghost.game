using Ghost.Data.Interface;
using Ghost.Model.Ghost;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ghost.Data
{
    public class GhostRepository : IGhostRepository
    {
        private GhostDataContext _context;
        private ILogger<GhostRepository> _logger;

        public GhostRepository(GhostDataContext context, ILogger<GhostRepository> logger)
        {
            _context = context;
            _logger = logger;

        }

        public IEnumerable<Word> GetWords()
        {
            _logger.LogInformation("Getting all words from the database");
            return _context.Words.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
