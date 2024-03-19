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
    public class GetCarCountByFuelHybridQueryHandler : IRequestHandler<GetCarCountByFuelHybridQuery, GetCarCountByFuelHybridQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelHybridQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelHybridQueryResult> Handle(GetCarCountByFuelHybridQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelHybrid();
            return new GetCarCountByFuelHybridQueryResult
            {
                CarCountByFuelHybrid = value
            };
        }
    }
}