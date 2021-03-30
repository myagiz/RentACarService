using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
   public  class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ModelYear).NotEmpty().WithMessage("Model yılı boş bırakılamaz.");
        }
    }
}
