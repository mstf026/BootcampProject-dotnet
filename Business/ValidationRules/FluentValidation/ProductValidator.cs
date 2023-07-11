using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(P => P.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(P => P.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p=>p.ModelNumber).Length(2);
            RuleFor(p => p.Name).Must(StartWithA);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
