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
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(100).WithMessage("Min 100 olmalıdır.");
            RuleFor(p => p.Description).NotEmpty().MinimumLength(10).MaximumLength(500);
            RuleFor(p => p.CarName).NotEmpty().MinimumLength(1).MaximumLength(50);
        }
    }
}
