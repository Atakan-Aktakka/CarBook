using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithPricingQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithPricingQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
          public List<GetCarWithPricingQueryResult> Handle()
        {
            var values = _repository.GetCarsWithPricings();
            return values.Select(x => new GetCarWithPricingQueryResult
            {
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl,
                BrandName = x.Car.Brand.Name,
                //PricingName = x.Pricing.Name,
                PricingAmount = x.Amount,
            }).ToList();
        }
    }
}