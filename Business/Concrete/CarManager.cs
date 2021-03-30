using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            return _carDal.GetAllCarDetails();
        }

        public CarDetailDto GetByCarId(int id)
        {
            return _carDal.GetByCarId(id);
        }

        public CarDetailDto GetByBrandId(int id)
        {
            return _carDal.GetByBrandId(id);
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(id);
        }

        [ValidationAspect(typeof(CarValidator))]
        public void Add(Car entity)
        {
           _carDal.Add(entity);
        }

        [ValidationAspect(typeof(CarValidator))]
        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }

        public void Delete(Car entity)
        {
           _carDal.Delete(entity);
        }
    }
}
