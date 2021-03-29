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
    public class CarsController : ControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetCarDetail()
        {
            var result = _carService.GetAllCarDetails();
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }



        [HttpGet("GetByCarId")]
        public ActionResult GetByCarId(int id)
        {
            var result = _carService.GetByCarId(id);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("GetByBrandId")]
        public ActionResult GetByBrandId(int id)
        {
            var result = _carService.GetByBrandId(id);
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpPost("Add")]
        public ActionResult Add(Car car)
        {
            try
            {
                _carService.Add(car);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("Update")]
        public ActionResult Update(Car car)
        {
            try
            {
               _carService.Update(car);
               return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("Delete")]
        public ActionResult Delete(Car car)
        {
            try
            {
                _carService.Delete(car);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
