using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
     public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryID).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.ProductName).Length(2,20);
            RuleFor(p => p.UnitPrice).GreaterThan(20).When(p => p.CategoryID == 1);
           // RuleFor(p => p.ProductName).Must(StartWithA);
        }

        public override ValidationResult Validate(ValidationContext<Product> context)
        {
            return base.Validate(context);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
