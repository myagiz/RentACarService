using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("GetByCarId")]
        public ActionResult GetByCarId(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpPost("Add")]
        public ActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("carId"))] int id, [FromForm] CarImage entity)
        {
            var result = _carImageService.Add(entity,file,id);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPut("Update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int id)
        {
            var getImage = _carImageService.Get(id);
            var result = _carImageService.Update(getImage,file,id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpDelete("Delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {

            var carImage = _carImageService.Get(Id);

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
