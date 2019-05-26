using AutoMapper;
using Ghost.Business.Interface;
using Ghost.Business.Interface.Dto;
using Ghost.Core.Exceptions;
using Ghost.Service.Interface;
using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static Ghost.Service.Interface.Enums.Enum;

namespace Ghost.Service
{
    public class GhostService : BaseService, IGhostService
    {
        private readonly IMapper mapper;
        private readonly IServiceProvider serviceProvider;

        public GhostService(
            ILogger<GhostService> logger,
            IServiceProvider serviceProvider,
            IMapper mapper)
            : base(logger)
        {
            this.mapper = mapper;
            this.serviceProvider = serviceProvider;
        }

        public async Task<CheckWordResponse> CheckWordAsync(CheckWordRequest request)
        {
            if (request == null)
            {
                throw new NullRequestException<CheckWordRequest>();
            }

            var response = new CheckWordResponse();

            var transaction = (ICheckWord)this.serviceProvider.GetService(typeof(ICheckWord));
            if (transaction == null)
            {
                this.Logger.LogError("Transaction {0} not found", typeof(ICheckWord));
                throw new TransactionNotFoundException(typeof(ICheckWord));
            }

            transaction.StartingWord = GetStartingWord(request);
            transaction.Round = request.Round;
            transaction.Turn = request.Turn;

            if (await transaction.ExecuteAsync())
            {
                response = this.mapper.Map<CheckWordDto, CheckWordResponse>(transaction.Response);
            }

            return response;
        }

        /// <summary>
        /// Return the starting word depending on who is playing in the current round
        /// </summary>
        /// <param name="request">Request with the value of the current word and the letter typed</param>
        /// <returns>Starting word</returns>
        private string GetStartingWord(CheckWordRequest request)
        {
            return request.Turn == Player.Computer ?
                                    string.Concat(request.ComputedWord, request.LetterTyped) :
                                    string.Concat(request.HumanWord, request.LetterTyped);
        }
    }
}
