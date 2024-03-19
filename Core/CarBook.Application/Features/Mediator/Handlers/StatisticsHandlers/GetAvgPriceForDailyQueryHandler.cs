using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgPriceForDailyQueryHandler : IRequestHandler<GetAvgPriceForDailyQuery, GetAvgPriceForDailyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgPriceForDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgPriceForDailyQueryResult> Handle(GetAvgPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForDaily();
            return new GetAvgPriceForDailyQueryResult
            {
                AvgPriceForDaily = value
            };
        }
    }
}