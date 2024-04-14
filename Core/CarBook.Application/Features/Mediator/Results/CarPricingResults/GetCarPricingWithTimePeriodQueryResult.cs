using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingWithTimePeriodQueryResult
    {
       public string Model { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal MounthlyAmount { get; set; }
        public decimal HourlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
        public string Brand { get; set; }
    }
}