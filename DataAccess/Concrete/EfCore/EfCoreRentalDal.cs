using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreRentalDal:EfEntityRepository<Rental,RentACarServiceContext>,IRentalDal
    {
    }
}
