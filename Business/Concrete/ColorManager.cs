using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
        }
    }
}
