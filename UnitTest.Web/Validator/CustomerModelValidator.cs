using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTest.Web.Model;

namespace UnitTest.Web.Validator
{
    public class CustomerModelValidator: AbstractValidator<CustomerModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.LastName).NotNull().NotEmpty();
            RuleFor(c => c.Name).Must(ValidateName).WithMessage("Invalidate Name");
            RuleFor(c => c.ProductIds).NotNull().NotEmpty().WithMessage("Product ids is must not empty");
            RuleForEach(c => c.ProductIds).Must(s => s > 5).WithMessage("Product ids  must more than 5");

        }

        public bool ValidateName(string name)
        {
            return name == "hack";
        }
    }

 
}