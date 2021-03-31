using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        private IResult CheckImageLimitExceeded(int id)
        {
            if (_carImageDal.GetAll(image => image.CarId == id).Count >= 5)
            {
                return new ErrorResult(Messages.CarImagesCountExceded);
            }

            return new SuccessResult();

        }

        public List<CarImage> GetAll()
        {
            return _carImageDal.GetAll();
        }

        public IResult Add(CarImage entity, IFormFile file, int id)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(id));
            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Add(file);
            if (imageResult!=null)
            {
                entity.ImagePath = imageResult.Message;
                _carImageDal.Add(entity);
                return new SuccessResult(Messages.succeed);
            }

            return new ErrorResult(imageResult.Message);

        }

        public IResult Update(CarImage entity, IFormFile file, int id)
        {
            var isImage = _carImageDal.Get(c => c.CarId == entity.CarId);

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            entity.ImagePath = updatedFile.Message;
            _carImageDal.Update(entity);
            return new SuccessResult("Car image updated");
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }
    }
}
