using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<CarDetailDto> GetAllCarDetails();
        Car GetById(int id);
        void Add(Car entity);
        void Update(Car entity);
        void Delete(Car entity);
    }
}
