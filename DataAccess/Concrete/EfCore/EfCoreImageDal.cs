using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreImageDal : EfEntityRepository<CarImage, RentACarServiceContext>, ICarImageDal
    {
        public List<CarImageDetail> GetByCarId(int carId)
        {
            using (var context = new RentACarServiceContext())
            {
                var result = from image in context.CarImage.Where(x => x.CarId == carId)
                             join car in context.Cars on image.CarId equals car.CarId
                             select new CarImageDetail
                             {
                                 CarImageId = image.CarImageId,
                                 ImagePath = image.ImagePath,
                                 CarId = car.CarId,
                                 DateTime = image.DateTime
                             };
                return result.ToList();
            }
        }
    }
}
