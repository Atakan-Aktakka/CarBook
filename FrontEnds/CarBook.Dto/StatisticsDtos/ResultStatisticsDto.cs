using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        public decimal avgPriceForDaily { get; set; }
        public decimal avgRentPriceForWeekl { get; set; }
        public decimal avgRentPriceForHourly { get; set; }
        public int carCountByTranmissionIsAuto { get; set; }
        public int carCountByKmSmallerThen1000 { get; set; }
        public int carCountByFuelGasolineOrDiesel { get; set; }
        public int carCountByFuelHybrid { get; set; }
        public string carBrandAndModelByRentPriceDailyMax { get; set; }
        public string carBrandAndModelByRentPriceDailyMin { get; set; }
        public string brandNameByMaxCar { get; set; }
        public string blogTitleByMaxBlogComment { get; set; }
    }
}