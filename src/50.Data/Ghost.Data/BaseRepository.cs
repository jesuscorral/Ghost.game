using Microsoft.Extensions.Logging;

namespace Ghost.Data
{
    public abstract class BaseRepository
    {
        protected readonly GhostDataContext context;
        private readonly ILogger<GhostRepository> logger;
        
        public BaseRepository(
            ILogger<GhostRepository> logger, 
            GhostDataContext context)
        {
            this.logger = logger;
            this.context = context;
        }
    }
}