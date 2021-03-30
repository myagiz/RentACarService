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
    public class RentalsController : ControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var result = _rentalService.GetAllRentalDetails();
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest();
        }


        [HttpGet("GetByRentalId")]
        public ActionResult GetByRentalId()
        {
            return 
        }


        [HttpPost("Add")]
        public ActionResult Add(Rental rental)
        {
            try
            {
                _rentalService.Add(rental);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
