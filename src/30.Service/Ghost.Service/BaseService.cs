using Microsoft.Extensions.Logging;

namespace Ghost.Service
{
    public abstract class BaseService
    {
        protected ILogger Logger { get; private set; }

        public BaseService(
            ILogger logger)
        {
            this.Logger = logger;
        }
    }
}
