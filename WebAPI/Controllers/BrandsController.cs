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
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;
        private ICarService _carService;

        public BrandsController(IBrandService brandService, ICarService carService)
        {
            _brandService = brandService;
            _carService = carService;
        }


        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var result = _brandService.GetAll();
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("GetCarsByBrandId")]
        public ActionResult GetCarsByBrandId(int id)
        {
            var result = _carService.GetByBrandId(id);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost("Add")]
        public ActionResult Add(Brand brand)
        {
            try
            {
                _brandService.Add(brand);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("Update")]
        public ActionResult Update(Brand brand)
        {
            try
            {
                _brandService.Update(brand);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("Delete")]
        public ActionResult Delete(Brand brand)
        {
            try
            {
                _brandService.Delete(brand);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
