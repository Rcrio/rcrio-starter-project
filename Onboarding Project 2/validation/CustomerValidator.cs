using FluentValidation;
using Onboarding_Project_2.models;

namespace Onboarding_Project_2.validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(customer => customer.loginEmail)
                .NotNull().WithMessage("You did not enter an email. Please try again.")
                .EmailAddress().WithMessage("Please use a correct email format.");
            RuleFor(customer => customer.loginPassword)
                .NotNull().WithMessage("You did not enter a password. Please try again.");
            RuleFor(customer => customer.registerEmail)
                .NotNull().WithMessage("You did not enter an email. Please try again.")
                .EmailAddress().WithMessage("Please use a correct email format.");
            RuleFor(customer => customer.registerPassword)
                .NotNull().WithMessage("You did not enter a password. Please try again.");
            RuleFor(customer => customer.registerFirstName)
                .NotNull().WithMessage("You did not enter a first name. Please try again.");
            RuleFor(customer => customer.registerLastName)
                .NotNull().WithMessage("You did not enter a last name. Please try again.");
            RuleFor(customer => customer.registerPhoneNo)
                .NotNull().WithMessage("You did not enter a phone number. Please try again.");

        }



    }
}
