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
    public class GetAvgPriceForHourlyQueryHandler : IRequestHandler<GetAvgPriceForHourlyQuery, GetAvgPriceForHourlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgPriceForHourlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgPriceForHourlyQueryResult> Handle(GetAvgPriceForHourlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForHourly();
            return new GetAvgPriceForHourlyQueryResult
            {
                AvgPriceForHourly = value
            };
        }
    }
}