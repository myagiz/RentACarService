using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        public List<Rental> GetAll()
        {
            return _rentalDal.GetAll();
        }

        public List<RentalDetailDto> GetAllRentalDetails()
        {
            return _rentalDal.GetAllRentalDetails();
        }

        public RentalDetailDto GetByRentalId(int id)
        {
            return _rentalDal.GetByRentalId(id);
        }

        public RentalDetailDto GetByCustomerId(int id)
        {
            return _rentalDal.GetByCustomerId(id);
        }

        public Rental GetById(int id)
        {
           return _rentalDal.GetById(id);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public void Add(Rental entity)
        {
            _rentalDal.Add(entity);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public void Update(Rental entity)
        {
           _rentalDal.Update(entity);
        }

        public void Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
        }
    }
}
