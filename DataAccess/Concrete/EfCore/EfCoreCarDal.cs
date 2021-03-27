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
    public class EfCoreCarDal:EfEntityRepository<Car,RentACarServiceContext>,ICarDal
    {
        public Car GetById(int id)
        {
            using (var context=new RentACarServiceContext())
            {
                var entity= context.Cars.Find(id);
                if (entity!=null)
                {
                    context.Cars.Where(x => x.CarId == id).FirstOrDefault();
                }

                return entity;
            }
        }
    }
}
