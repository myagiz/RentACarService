using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
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

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(), Messages.ProductsListed);
        }

        public IDataResult<CarDetailDto> GetByCarId(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetByCarId(id),Messages.succeed);
        }

        public IDataResult<List<CarDetailDto>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByBrandId(id),Messages.succeed);
        }

        public IDataResult<List<CarDetailDto>> GetByColorId(int id)
        {
           return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByColorId(id),Messages.succeed);
        }


        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(id),Messages.succeed);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car entity)
        {
           _carDal.Add(entity);
           return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccessResult(Messages.updated);
        }

        public IResult Delete(Car entity)
        {
           _carDal.Delete(entity);
           return new SuccessResult();
        }
    }
}
