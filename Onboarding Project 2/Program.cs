using Onboarding_Project_2.methods;
using Onboarding_Project_2.models;
using Onboarding_Project_2.validation;
using System;
using System.Data.SqlClient;

namespace Onboarding_Project_2
{

    public class Program
    {
        public static Customer customer = new Customer();

        static void Main(string[] args)
        {
            MainMenu();
        }

        static public void MainMenu()
        {
            Console.WriteLine("Welcome to the Onboarding sign-up/log-in project." +
                "\n To log-in, please enter \'login\'." +
                "\n To register, please enter \'register\'." +
                "\nTo exit the program, please enter \'exit\'.");

            int mainMenuConfirmer = 0;

            while (mainMenuConfirmer == 0)
            {
                string loginOrRegister = Console.ReadLine();

                switch (loginOrRegister)
                {
                    case "exit":
                        Environment.Exit(0);
                        break;

                    case "login":
                        Login();
                        break;

                    case "register":
                        Register();
                        break;

                    default:
                        Console.WriteLine("You either entered nothing or entered an incorrect option. Options are case sensitive. Please try again.");
                        break;
                }
            }
        }

        static public void Login()
        {
            var conn = SqlMethods.GetConnection();

            bool incorrect2 = true;
            Console.WriteLine("Welcome to the log-in page.");
            while (incorrect2 == true)
            {
                Console.Write("Please enter an email: ");
                customer.loginEmail = Console.ReadLine();
                Validators.ValidateCustomerLoginEmail();

                Console.Write("Please enter a password: ");
                customer.loginPassword = Console.ReadLine();
                Validators.ValidateCustomerLoginPassword();

                SqlMethods.loginToAccount();
            }
        }

        static public void Register()
        {
            var conn = SqlMethods.GetConnection();
            //userEmail, userPassword, userFirstName, userLastName, userPhoneNo
            Console.Write("You have chosen to register a new user.");
            Console.Write("\nPlease enter an email: ");
            customer.registerEmail = Console.ReadLine();
            Validators.ValidateCustomerRegisterEmail();

            Console.Write("Please enter a password: ");
            customer.registerPassword = Console.ReadLine();
            Validators.ValidateCustomerRegisterPassword();

            Console.Write("Please enter a first name: ");
            customer.registerFirstName = Console.ReadLine();
            Validators.ValidateCustomerRegisterFirstName();

            Console.Write("Please enter a last name: ");
            customer.registerLastName = Console.ReadLine();
            Validators.ValidateCustomerRegisterLastName();

            Console.Write("Please enter a phone number: ");
            customer.registerPhoneNo = Console.ReadLine();
            Validators.ValidateCustomerRegisterPhoneNo();

            SqlMethods.newAccountCreate();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
