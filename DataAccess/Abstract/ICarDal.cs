using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailDto GetByCarId(int carId);
        List<CarDetailDto> GetByBrandId(int brandId);
        List<CarDetailDto> GetByColorId(int colorId);
    }
}
