using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidaitonRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Product_Name).NotEmpty();
            RuleFor(p => p.Product_Name).MinimumLength(2);
            RuleFor(p => p.Unit_Price).NotEmpty();
            RuleFor(p => p.Unit_Price).GreaterThan(0);

        }

        
    }
}
