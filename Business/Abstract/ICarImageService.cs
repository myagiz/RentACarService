using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        List<CarImage> GetAll();
        IResult Add(CarImage entity, IFormFile file, int id);
        IResult Update(CarImage entity, IFormFile file, int id);
        IResult Delete(CarImage entity);
    }
}
