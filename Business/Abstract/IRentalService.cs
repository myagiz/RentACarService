using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        List<Rental> GetAll();
        List<RentalDetailDto> GetAllRentalDetails();
        RentalDetailDto GetByRentalId(int id);
        Rental GetById(int id);
        void Add(Rental entity);
        void Update(Rental entity);
        void Delete(Rental entity);
    }
}
