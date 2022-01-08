using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using Onboarding_Project_2.models;
using Onboarding_Project_2.validation;

namespace Onboarding_Project_2
{
    
    class Program
    {

        static void Main(string[] args)
        {
            //"Server=DESKTOP-1G08UJK;Database=Onboarding;Trusted_Connection=True;MultipleActiveResultSets=true;"
            //"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database2.mdf;Integrated Security=True"

            //String and code to connect to SQL. Reminder to check app.config for connection string.
            string connectionString = "Server=DESKTOP-1G08UJK;Database=Onboarding;Trusted_Connection=True;MultipleActiveResultSets=true;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            Customer customer = new Customer();
            
            //NOT SURE ABOUT THIS, probably should remove it.
            //CustomerValidator validator = new CustomerValidator();
            //var result = validator.Validate(customer);


            Console.WriteLine("Welcome to the Onboarding sign-up/log-in project.");
            Console.WriteLine("To log-in, please enter \'login\'");
            Console.WriteLine("To register, please enter \'register\'");
            bool incorrect = true;
            int confirmer = 0;


            while (incorrect)
            {
                string loginOrRegister = Console.ReadLine();

                switch(loginOrRegister)
                {
                    case "login":
                        incorrect = false;
                        confirmer = confirmer + 1;
                        break;

                    case "register":
                        incorrect = false;
                        confirmer = confirmer + 2;
                        break;

                    default:
                        Console.WriteLine("You either entered nothing or entered an incorrect option. Options are case sensitive. Please try again.");
                        break;
                }
            }

            if (confirmer == 1)
            {
                bool incorrect2 = true;

                while (incorrect2 == true)
                {
                    Console.Write("Welcome to the log-in page. Please enter an email: ");
                    customer.loginEmail = Console.ReadLine();

                    Console.Write("Please enter a password: ");
                    customer.loginPassword = Console.ReadLine();

                    SqlCommand accountLogin = conn.CreateCommand();
                    string accountLoginString =
                        "SELECT userEmail, userPassword FROM dbo.userLogin WHERE userEmail = @userLoginEmail AND userPassword = @userLoginPassword";
                    accountLogin.Parameters.AddWithValue("@userLoginEmail", customer.loginEmail);
                    accountLogin.Parameters.AddWithValue("@userLoginPassword", customer.loginPassword);
                    accountLogin.CommandText = accountLoginString;
                    accountLogin.CommandType = System.Data.CommandType.Text;
                    SqlDataReader reader = accountLogin.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        //string verifyEmailLogin = reader[0].ToString();
                        //string verifyPasswordLogin = reader[1].ToString();

                        Console.WriteLine("Successful login.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect email or password. Please try again.\n");
                        incorrect2 = true;
                    }
                }

                


            }

            else if (confirmer == 2)
            {
                
                //userEmail, userPassword, userFirstName, userLastName, userPhoneNo
                Console.Write("You have chosen to register a new user.");
                Console.Write("\nPlease enter an email: ");
                customer.registerEmail = Console.ReadLine();

                Console.Write("Please enter a password: ");
                customer.registerPassword = Console.ReadLine();

                Console.Write("Please enter a first name: ");
                customer.registerFirstName = Console.ReadLine();

                Console.Write("Please enter a last name: ");
                customer.registerLastName = Console.ReadLine();

                Console.Write("Please enter a phone number: ");
                customer.registerPhoneNo = Console.ReadLine();

                SqlCommand newAccountCreate = conn.CreateCommand();
                string newAccountCreateString = "INSERT INTO dbo.userLogin (userEmail, userPassword, userFirstName, userLastName, userPhoneNo) " +
                    "VALUES (@userRegEmail, @userRegPassword, @userRegFirstName, @userRegLastName, @userRegPhoneNo);";
                newAccountCreate.Parameters.AddWithValue("@userRegEmail", customer.registerEmail);
                newAccountCreate.Parameters.AddWithValue("@userRegPassword", customer.registerPassword);
                newAccountCreate.Parameters.AddWithValue("@userRegFirstName", customer.registerFirstName);
                newAccountCreate.Parameters.AddWithValue("@userRegLastName", customer.registerLastName);
                newAccountCreate.Parameters.AddWithValue("@userRegPhoneNo", customer.registerPhoneNo);
                Console.WriteLine(newAccountCreateString);
                newAccountCreate.CommandText = newAccountCreateString;
                newAccountCreate.CommandType = System.Data.CommandType.Text;
                newAccountCreate.ExecuteNonQuery();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

    }
}
