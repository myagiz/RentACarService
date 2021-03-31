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
    public class EfCoreRentalDal:EfEntityRepository<Rental,RentACarServiceContext>,IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (var context=new RentACarServiceContext())
            {
                var result = from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                    join car in context.Cars on rental.CarId equals car.CarId
                    join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                    select new RentalDetailDto
                    {
                        RentalId = rental.RentalId,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate,
                        CustomerName = customer.CompanyName,
                        CarName = car.CarName,
                    };
                return result.ToList();
            }
        }

        public RentalDetailDto GetByRentalId(int rentalId)
        {
            using (var context=new RentACarServiceContext())
            {
                var result=from rental in context.Rentals.Where(x=>x.RentalId==rentalId)
                    join car in context.Cars on rental.CarId equals car.CarId
                    join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                    select new RentalDetailDto
                    {
                        RentalId = rental.RentalId,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate,
                        CustomerName = customer.CompanyName,
                        CarName = car.CarName,
                    };
                return result.SingleOrDefault();
            }
        }

        public RentalDetailDto GetByCustomerId(int customerId)
        {
            using (var context=new RentACarServiceContext())
            {
                var result=from rental in context.Rentals.Where(x=>x.CustomerId==customerId)
                    join car in context.Cars on rental.CarId equals car.CarId
                    join customer in context.Customers on rental.CustomerId equals customer.CustomerId
                    select new RentalDetailDto
                    {
                        RentalId = rental.RentalId,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate,
                        CustomerName = customer.CompanyName,
                        CarName = car.CarName,
                    };
                return result.SingleOrDefault();
            }
        }
    }
}
