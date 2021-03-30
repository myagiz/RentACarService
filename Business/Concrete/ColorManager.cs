using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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

        [ValidationAspect(typeof(ColorValidator))]
        public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }

        [ValidationAspect(typeof(ColorValidator))]
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
