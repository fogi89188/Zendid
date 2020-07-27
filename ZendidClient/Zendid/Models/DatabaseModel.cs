using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zendid.Models
{
    class DatabaseModel
    {

        #region Private Members

        private static readonly DatabaseModel instance = new DatabaseModel();
        private static string connectionString = "server=localhost;user=root;database=zendid;port=3306;password=password";

        #endregion

        #region Public Members

        public static DatabaseModel Instance
        {
            get
            {
                return instance;
            }
        }

        public static MySqlConnection connection = new MySqlConnection(connectionString);

        public static string currentEmail = "";

        public static int currentId = 0;

        public static bool isAdmin = false;

        public static int numberOfSuggestedNames = 0;

        public static DataTable dataTable = new DataTable("favourites");

        #endregion

        #region Commands

        /// <summary>
        /// getter setter for currentEmail
        /// </summary>
        public static string CurrentEmail
        {
            get
            {
                return currentEmail;
            }
            set
            {
                currentEmail = value;
            }
        }

        /// <summary>
        /// getter setter for currentEmail
        /// </summary>
        public static int CurrentId
        {
            get
            {
                return currentId;
            }
            set
            {
                currentId = value;
            }
        }

        /// <summary>
        /// getter setter for isAdmin
        /// </summary>
        public static bool IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = value;
            }
        }

        /// <summary>
        /// initializes the singleton class and opens the connection to the local database
        /// </summary>
        public static void Initialize()
        {
            try
            {
                //opening the connection
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// checks if the login information is correct and if so, logs in the user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string email, string password)
        {
            if (email == null || password == null)
            {
                return false;
            }
            //create new command with statement mysqlStatement
            string mysqlStatement = $"SELECT password, isAdmin, id FROM Users WHERE email = \"{email}\"; ";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            //creare a reader to comapre data from the database
            MySqlDataReader reader = command.ExecuteReader();
            //check if password exists
            if (reader.Read())
            {
                //checks if the password is correct
                bool passwordCheck = reader.GetString("password").Equals(password);
                if (passwordCheck == true)
                {
                    CurrentEmail = email;
                    CurrentId = reader.GetInt16("id");
                    IsAdmin = reader.GetBoolean("isAdmin");
                }
                reader.Close();
                return passwordCheck;
            }
            reader.Close();
            return false;
        }

        /// <summary>
        /// set current parameters to 0 or null, essentially forgetting aout the 
        /// </summary>
        public void Logout()
        {
            CurrentEmail = null;
            IsAdmin = false;
            CurrentId = 0;
        }

        /// <summary>
        /// change email of current user from the database
        /// </summary>
        /// <param name="newEmail"></param>
        public void ChangeEmail(string newEmail)
        {
            //create new command with statement mysqlStatement
            string mysqlStatement = $"UPDATE Users SET email = \'{newEmail}\' WHERE id = {CurrentId};";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// change password of current user from the database
        /// </summary>
        /// <param name="newPassword"></param>
        public void ChangePassword(string newPassword)
        {
            //create new command with statement mysqlStatement
            string mysqlStatement = $"UPDATE Users SET password = \'{newPassword}\' WHERE id = {CurrentId};";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// remove an account form the database
        /// </summary>
        public void DeleteAccount()
        {
            //create new command with statement mysqlStatement
            string mysqlStatement = $"DELETE FROM Users WHERE id = {CurrentId};";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
            Logout();
        }

        /// <summary>
        /// creates a user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public void AddUser(string email, string password)
        {
            string mysqlStatement = $"INSERT INTO Users (email, password, isAdmin) VALUES(\"{email}\", \"{password}\", false);";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
            Login(email, password);
        }

        /// <summary>
        /// get random name from the database based on the race and sex
        /// </summary>
        /// <param name="race"></param>
        /// <param name="sex"></param>
        /// <returns></returns>

        #endregion

        #region Constructor
        private DatabaseModel()
        {
        }
        static DatabaseModel()
        {
        }
        #endregion

    }
}
