using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Onboarding_Project_2;
using Onboarding_Project_2.models;

namespace Onboarding_Project_2.validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(customer => customer.loginEmail)
                .NotNull().WithMessage("Please enter an email.")
                .EmailAddress().WithMessage("Please use a correct email format.");
            RuleFor(customer => customer.loginPassword)
                .NotNull().WithMessage("Please enter a password.");
            RuleFor(customer => customer.registerEmail)
                .NotNull().WithMessage("Please enter an email.")
                .EmailAddress().WithMessage("Please use a correct email format.");
            RuleFor(customer => customer.registerPassword)
                .NotNull().WithMessage("Please enter a password.");
            RuleFor(customer => customer.registerFirstName)
                .NotNull().WithMessage("Please enter a first name.");
            RuleFor(customer => customer.registerLastName)
                .NotNull().WithMessage("Please enter a last name.");
            RuleFor(customer => customer.registerPhoneNo)
                .NotNull().WithMessage("Please enter a phone number.");
         
        }



    }
}
