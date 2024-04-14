using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingListWithBrandDto
    {
        public string model { get; set; }
		public decimal hourlyAmount { get; set; }
		public decimal dailyAmount { get; set; }
		public decimal mounthlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
        public string Brand { get; set; }
    }
}