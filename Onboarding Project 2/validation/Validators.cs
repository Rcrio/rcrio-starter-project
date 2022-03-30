using FluentValidation;
using FluentValidation.Results;
using System;

namespace Onboarding_Project_2.validation
{
    static public class Validators
    {
        //Login
        static public void ValidateCustomerLoginEmail()
        {
            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(Program.customer, opt => opt.IncludeProperties(x => x.loginEmail));
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Program.Login();
            }
        }

        static public void ValidateCustomerLoginPassword()
        {
            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(Program.customer, opt => opt.IncludeProperties(x => x.loginPassword));
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Program.Login();
            }
        }

        //Register

        static public void ValidateCustomerRegisterEmail()
        {

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(Program.customer, opt => opt.IncludeProperties(x => x.registerEmail));
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Program.Register();
            }
        }

        static public void ValidateCustomerRegisterPassword()
        {

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(Program.customer, opt => opt.IncludeProperties(x => x.registerEmail));
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Program.Register();
            }
        }

        static public void ValidateCustomerRegisterFirstName()
        {

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(Program.customer, opt => opt.IncludeProperties(x => x.registerFirstName));
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Program.Register();
            }
        }

        static public void ValidateCustomerRegisterLastName()
        {

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(Program.customer, opt => opt.IncludeProperties(x => x.registerLastName));
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Program.Register();
            }
        }

        static public void ValidateCustomerRegisterPhoneNo()
        {

            CustomerValidator validator = new CustomerValidator();
            ValidationResult result = validator.Validate(Program.customer, opt => opt.IncludeProperties(x => x.registerPhoneNo));
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine(failure.ErrorMessage);
                }
                Program.Register();
            }
        }

    }
}
