using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreCarDal : EfEntityRepository<Car, RentACarServiceContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (var context = new RentACarServiceContext())
            {
                var result = from car in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetByCarId(int carId)
        {
            using (var context = new RentACarServiceContext())
            {
                var result = from car in context.Cars.Where(x => x.CarId == carId)
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 ModelYear = car.ModelYear,
                                 Description = car.Description,
                                 DailyPrice = car.DailyPrice,
                                 ColorName = color.Name,
                                 BrandName = brand.Name,
                                 Status = !context.Rentals.Any(rental => rental.Car.CarId == carId && rental.ReturnDate == null)
                             };
                return result.SingleOrDefault();
            }
        }

        public CarDetailDto GetByBrandId(int brandId)
        {
            using (var context=new RentACarServiceContext())
            {
               var result=from car in context.Cars.Where(x=>x.BrandId==brandId)
                   join color in context.Colors on car.ColorId equals color.ColorId
                   join brand in context.Brands on car.BrandId equals brand.BrandId
                   select new CarDetailDto
                   {
                       CarId = car.CarId,
                       ModelYear = car.ModelYear,
                       Description = car.Description,
                       DailyPrice = car.DailyPrice,
                       ColorName = color.Name,
                       BrandName = brand.Name,
                       Status = !context.Rentals.Any(rental => rental.Car.BrandId == brandId && rental.ReturnDate == null)
                   };
               return result.SingleOrDefault();
            }
        }
    }
}
