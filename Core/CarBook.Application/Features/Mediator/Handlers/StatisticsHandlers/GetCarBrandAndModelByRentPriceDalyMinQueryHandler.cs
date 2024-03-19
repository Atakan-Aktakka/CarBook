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
    public class GetCarBrandAndModelByRentPriceDalyMinQueryHandler : IRequestHandler<GetCarBrandAndModelByRentPriceDalyMinQuery, GetCarBrandAndModelByRentPriceDalyMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelByRentPriceDalyMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModelByRentPriceDalyMinQueryResult> Handle(GetCarBrandAndModelByRentPriceDalyMinQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelByRentPriceDalyMin();
            return new GetCarBrandAndModelByRentPriceDalyMinQueryResult
            {
                CarBrandAndModelByRentPriceDailyMin = value
            };
        }
    }
}