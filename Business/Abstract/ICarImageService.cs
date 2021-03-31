using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        List<CarImage> GetAll();
        List<CarImageDetail> GetByCarId(int id);
        CarImage Get(int id);
        IResult Add(CarImage entity, IFormFile file, int id);
        IResult Update(CarImage entity, IFormFile file, int id);
        IResult Delete(CarImage entity);
    }
}
