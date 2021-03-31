using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarImageDetail:IDto
    {
        public int CarImageId { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
       
        public DateTime DateTime = DateTime.Now;
    }
}
