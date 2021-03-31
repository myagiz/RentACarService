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
    public class ColorsController : ControllerBase
    {
        private IColorService _colorService;
        private ICarService _carService;

        public ColorsController(IColorService colorService, ICarService carService)
        {
            _colorService = colorService;
            _carService = carService;
        }


        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("GetCarsByColorId")]
        public ActionResult GetCarsByColorId(int id)
        {
            var result = _carService.GetByColorId(id);
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpPost("Add")]
        public ActionResult Add(Color color)
        {
            try
            {
                _colorService.Add(color);
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }


        [HttpPut("Update")]
        public ActionResult Update(Color color)
        {
            try
            {
                _colorService.Update(color);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("Delete")]
        public ActionResult Delete(Color color)
        {
            try
            {
                _colorService.Delete(color);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
