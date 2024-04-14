using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(z => z.PricingID == 2).ToList();
            return values;
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {

            /*  var values = from x in _context.CarPricings
                           group x by x.PricingID into g
                           select new
                           {
                               CarId = g.Key,
                               HourlyPrice = g.Where(y => y.CarPricingID == 2).Sum(z => z.Amount),
                               DailyPrice = g.Where(y => y.CarPricingID == 3).Sum(z => z.Amount),
                               MonthlyPrice = g.Where(y => y.CarPricingID == 4).Sum(z => z.Amount),
                           };
              return values.ToList();*/
            throw new NotImplementedException();

        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([1],[2],[3])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader["1"]),
                                Convert.ToDecimal(reader["2"]),
                                Convert.ToDecimal(reader["3"])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}