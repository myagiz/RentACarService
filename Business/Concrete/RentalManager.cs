using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.listed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails(),Messages.listed);
        }

        public IDataResult<RentalDetailDto> GetByRentalId(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetByRentalId(id),Messages.succeed);
        }

        public IDataResult<RentalDetailDto> GetByCustomerId(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetByCustomerId(id),Messages.succeed);
        }

        public IDataResult<Rental> GetById(int id)
        {
           return new SuccessDataResult<Rental>(_rentalDal.GetById(id),Messages.succeed);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.added);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental entity)
        {
           _rentalDal.Update(entity);
           return new SuccessResult(Messages.updated);
        }

        public IResult Delete(Rental entity)
        {
            if (entity!=null)
            {
                _rentalDal.Delete(entity);
                return new SuccessResult(Messages.deleted);
            }
            return new ErrorResult("No delete rental.");
        }
    }
}
