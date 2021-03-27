using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public Rental GetById(int id)
        {
           return _rentalDal.GetById(id);
        }

        public void Add(Rental entity)
        {
            _rentalDal.Add(entity);
        }

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
