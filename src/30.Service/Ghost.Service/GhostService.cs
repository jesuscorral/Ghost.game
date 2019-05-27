using AutoMapper;
using Ghost.Business.Interface;
using Ghost.Business.Interface.Dto;
using Ghost.Core.Exceptions;
using Ghost.Service.Interface;
using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

            // The round is initialize with value = 1
            if (request.Round != request.Word.Length)
            {
                throw new Exception("The word is bigger than the corresponding round");
            }

            // Check if the input are only letters
            CheckInput(request.Word);
            
            var response = new CheckWordResponse();

            var transaction = (ICheckWord)this.serviceProvider.GetService(typeof(ICheckWord));
            if (transaction == null)
            {
                this.Logger.LogError("Transaction {0} not found", typeof(ICheckWord));
                throw new TransactionNotFoundException(typeof(ICheckWord));
            }

            transaction.StartingWord = request.Word;
            transaction.Round = request.Round;
            transaction.Turn = request.Turn;

            if (await transaction.ExecuteAsync())
            {
                response = this.mapper.Map<CheckWordDto, CheckWordResponse>(transaction.Response);
            }

            return response;
        }

        private void CheckInput(string word)
        {
            if(!Regex.IsMatch(word, @"^[a-zA-Z]+$"))
            {
                throw new Exception("The word is bigger than the corresponding round");
            }
        }
    }
}
