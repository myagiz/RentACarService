using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EfCore
{
    public class EfCoreCustomerDal:EfEntityRepository<Customer,RentACarServiceContext>,ICustomerDal
    {
    }
}
