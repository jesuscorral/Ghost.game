using Ghost.Core.Exceptions;
using Ghost.Data.Interface;
using Ghost.Service.Interface;
using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ghost.Service
{
    public class GhostService : BaseService, IGhostService
    {
        private readonly IGhostRepository ghostRepository;

        public GhostService(
            ILogger<GhostService> logger,
            IGhostRepository ghostRepository)
            : base(logger)
        {
            this.ghostRepository = ghostRepository;
        }

        public async Task<CheckWordResponse> CheckWordAsync(CheckWordRequest request)
        {
            if (request == null)
            {
                throw new NullRequestException<CheckWordRequest>();
            }

            var t = await this.ghostRepository.GetWordsAsync();

            //var transaction = this.TransactionManager.CreateTransaction<ICheckWord>(t =>
            //{
            //    //t.Capacity = this.capacityConverter.ToCapacity(request);
            //    //t.PartyId = request.PartyId;
            //});

            var response = new CheckWordResponse();
            //if (await this.TransactionManager.ExecuteAsync(transaction))
            //{
            //    //response.Data = this.capacityConverter.ToCapacityDTO(transaction.Capacity);
            //}

            //response.Errors = transaction.ValidationResults;

            return response;
        }
    }
}
