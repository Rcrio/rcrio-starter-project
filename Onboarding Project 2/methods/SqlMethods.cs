using System;
using System.Data.SqlClient;

namespace Onboarding_Project_2.methods
{
    public class SqlMethods
    {
        //SQL code to connect to database
        public static SqlConnection GetConnection()
        {
            //String and code to connect to SQL. Reminder to check app.config for connection string.
            string connectionString = "Server=DESKTOP-1G08UJK;Database=Onboarding;Trusted_Connection=True;MultipleActiveResultSets=true;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
        //SQL code to communicate with database for logging in
        public static void loginToAccount()
        {
            var conn = GetConnection();
            SqlCommand accountLogin = conn.CreateCommand();
            string accountLoginString =
                "SELECT userEmail, userPassword FROM dbo.userLogin WHERE userEmail = @userLoginEmail AND userPassword = @userLoginPassword";
            accountLogin.Parameters.AddWithValue("@userLoginEmail", Program.customer.loginEmail);
            accountLogin.Parameters.AddWithValue("@userLoginPassword", Program.customer.loginPassword);
            accountLogin.CommandText = accountLoginString;
            accountLogin.CommandType = System.Data.CommandType.Text;
            SqlDataReader reader = accountLogin.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                string verifyEmailLogin = reader[0].ToString();
                string verifyPasswordLogin = reader[1].ToString();

                if (verifyEmailLogin == Program.customer.loginEmail & verifyPasswordLogin == Program.customer.loginPassword)
                {
                    Console.WriteLine("Successful login. Press any key to exit.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Incorrect login. Please try again by pressing enter.\nIf you would like to return to the main menu, type \'return\'.");
                string loginReturnToMainMenu = Console.ReadLine();
                if (loginReturnToMainMenu == "return")
                {
                    Program.MainMenu();
                }
                else
                {

                }
            }
        }
        //SQL code to communicate with database for registering account
        public static void newAccountCreate()
        {
            var conn = GetConnection();
            SqlCommand newAccountCreate = conn.CreateCommand();
            string newAccountCreateString = "INSERT INTO dbo.userLogin (userEmail, userPassword, userFirstName, userLastName, userPhoneNo) " +
                "VALUES (@userRegEmail, @userRegPassword, @userRegFirstName, @userRegLastName, @userRegPhoneNo);";
            newAccountCreate.Parameters.AddWithValue("@userRegEmail", Program.customer.registerEmail);
            newAccountCreate.Parameters.AddWithValue("@userRegPassword", Program.customer.registerPassword);
            newAccountCreate.Parameters.AddWithValue("@userRegFirstName", Program.customer.registerFirstName);
            newAccountCreate.Parameters.AddWithValue("@userRegLastName", Program.customer.registerLastName);
            newAccountCreate.Parameters.AddWithValue("@userRegPhoneNo", Program.customer.registerPhoneNo);
            Console.WriteLine(newAccountCreateString);
            newAccountCreate.CommandText = newAccountCreateString;
            newAccountCreate.CommandType = System.Data.CommandType.Text;
            newAccountCreate.ExecuteNonQuery();
        }

    }
}
