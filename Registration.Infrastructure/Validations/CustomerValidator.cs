using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Registration.Core.Entities;
using Registration.Infrastructure.Validations.Methods;

namespace Registration.Infrastructure.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {

             RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("can't be empty or whitespace please check you model")
                .NotNull().WithMessage("can't be Null or whitespace please check you model")
                .Length( 50)
                .WithMessage("Please Check if length of character is 50");
            
             RuleFor(p => p.Password)
                 .NotNull()
                 .WithMessage("Please enter password")
                 .MinimumLength(6)
                 .WithMessage("please insert valid password is larger than 6 character");

             RuleFor(p => p.Email)
                 .NotEmpty()
                 .WithMessage("Please enter Email for this user")
                 .NotNull()
                 .WithMessage("Please enterEmail for this user")
                 .Must(p => !p.IsUniqueEmail())
                 .WithMessage("thisEmail is already exist");
        }
    }
}
