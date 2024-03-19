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
    public class GetAvgPriceForWeeklyQueryHandler : IRequestHandler<GetAvgPriceForWeeklyQuery, GetAvgPriceForWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgPriceForWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgPriceForWeeklyQueryResult> Handle(GetAvgPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForWeekly();
            return new GetAvgPriceForWeeklyQueryResult
            {
                AvgPriceForWeekly = value
            };
        }
    }
}