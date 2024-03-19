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
    public class GetCarBrandAndModelByRentPriceDalyMaxQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDalyMaxQuery, GetCarBrandAndModelByRentPriceDalyMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceDalyMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDalyMaxQueryResult> Handle(GetCarBrandAndModelByRentPriceDalyMaxQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceDalyMax();
            return new GetCarBrandAndModelByRentPriceDalyMaxQueryResult
            {
                CarBrandAndModelByRentPriceDailyMax = value
            };
        }
    }
}