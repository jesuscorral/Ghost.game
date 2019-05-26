using AutoMapper;
using Ghost.Core.Exceptions;
using Ghost.Data.Interface;
using Ghost.Model.Ghost;
using Ghost.Service.Interface;
using Ghost.Service.Interface.Dto;
using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ghost.Service
{
    public class GhostService : BaseService, IGhostService
    {
        private readonly IGhostRepository ghostRepository;
        private readonly IMapper mapper;

        public GhostService(
            ILogger<GhostService> logger,
            IGhostRepository ghostRepository,
            IMapper mapper)
            : base(logger)
        {
            this.ghostRepository = ghostRepository;
            this.mapper = mapper;
        }

        public async Task<CheckWordResponse> CheckWordAsync(CheckWordRequest request)
        {
            if (request == null)
            {
                throw new NullRequestException<CheckWordRequest>();
            }

            var t = await this.ghostRepository.GetWordsAsync();

            var response = new CheckWordResponse
            {
                // Map Word class from model to WordDto 
                Words = this.mapper.Map<IEnumerable<Word>, IEnumerable<WordDto>>(t)
            };

            //var transaction = this.TransactionManager.CreateTransaction<ICheckWord>(t =>
            //{
            //    //t.Capacity = this.capacityConverter.ToCapacity(request);
            //    //t.PartyId = request.PartyId;
            //});

           
            //if (await this.TransactionManager.ExecuteAsync(transaction))
            //{
            //    //response.Data = this.capacityConverter.ToCapacityDTO(transaction.Capacity);
            //}

            //response.Errors = transaction.ValidationResults;

            return response;
        }
}
}
