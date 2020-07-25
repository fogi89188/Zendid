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
        public string GetRandomName(string race, string sex)
        {
            //create new command with statement mysqlStatement
            string mysqlStatement = $"SELECT firstName FROM names WHERE race = \"{race}\" AND sex = \"{sex}\" ORDER BY RAND() LIMIT 1;";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            //creare a reader to comapre data from the database
            MySqlDataReader reader = command.ExecuteReader();
            string randomName = "";
            if (reader.Read())
            {
                randomName = reader.GetString("firstName");
            }
            reader.Close();
            return randomName;
        }

        /// <summary>
        /// adds a suggestion to the suggestions table so that the admin could add or remove suggested names
        /// </summary>
        /// <param name="name"></param>
        /// <param name="race"></param>
        /// <param name="sex"></param>
        public void Suggest(string name, string race, string sex)
        {
            string mysqlStatement = $"INSERT INTO suggestions (firstName, race, sex) VALUES(\"{name}\", \"{race}\", \"{sex}\");";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
            numberOfSuggestedNames++;
        }

        /// <summary>
        /// shows the first suggested name, so that the admin suggestion tab can load
        /// </summary>
        /// <returns></returns>
        public string SuggestedMostRecentName()
        {
            string mysqlStatement = $"SELECT firstName FROM Suggestions LIMIT 1;";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (numberOfSuggestedNames > 0)
            {
                reader.Read();
                string result = reader.GetString("firstName");
                reader.Close();
                return result;
            }
            return null;
        }

        /// <summary>
        /// shows the first suggested race, so that the admin suggestion tab can load
        /// </summary>
        /// <returns></returns>
        public string SuggestedMostRecentRace()
        {
            string mysqlStatement = $"SELECT race FROM Suggestions LIMIT 1;";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (numberOfSuggestedNames > 0)
            {
                reader.Read();
                string result = reader.GetString("race");
                reader.Close();
                return result;
            }
            return null;
        }

        /// <summary>
        /// shows the first suggested sex, so that the admin suggestion tab can load
        /// </summary>
        /// <returns></returns>
        public string SuggestedMostRecentSex()
        {
            string mysqlStatement = $"SELECT sex FROM Suggestions LIMIT 1;";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (numberOfSuggestedNames > 0)
            {
                reader.Read();
                string result = reader.GetString("sex");
                reader.Close();
                return result;
            }
            return null;
        }

        /// <summary>
        /// adds the first suggested name to the names table
        /// </summary>
        public void AddSuggestedName(string name, string race, string sex)
        {
            string mysqlStatement = $"INSERT INTO names (firstName, race, sex) VALUES(\"{name}\", \"{race}\", \"{sex}\");";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
            string mysqlStatement1 = $"DELETE FROM Suggestions LIMIT 1;";
            MySqlCommand command1 = new MySqlCommand(mysqlStatement1, connection);
            if (numberOfSuggestedNames > 0)
            {
                command1.ExecuteNonQuery();
                numberOfSuggestedNames--;
            }
        }

        /// <summary>
        /// removes the first suggested name from the suggestions table
        /// </summary>
        public void RemoveSuggestedName()
        {
            string mysqlStatement = $"DELETE FROM Suggestions LIMIT 1;";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            if (numberOfSuggestedNames > 0)
            {
                command.ExecuteNonQuery();
                numberOfSuggestedNames--;
            }
        }

        /// <summary>
        /// sets the counter for the number of suggested names so that the admin suggestions page can load and refresh correctly
        /// </summary>
        public void SetNumberOfSuggestedNames()
        {
            string mysqlStatement = $"SELECT COUNT(*) FROM suggestions;";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int count = reader.GetInt16("COUNT(*)");
            reader.Close();
            numberOfSuggestedNames = count;
        }

        /// <summary>
        /// establishes the initial datagrid connection in the favourites view
        /// </summary>
        public void FavouriteDataGridConnection(string email)
        {
            string mysqlStatement = $"SELECT * FROM favourites WHERE email = \"{CurrentEmail}\";";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            MySqlDataReader reader = command.ExecuteReader();
            //check if email exists
            if (reader.Read())
            {
                reader.Close();
            }
            //else create a new email favourites row in the favourites table
            else
            {
                reader.Close();
                mysqlStatement = $"INSERT INTO `writerhelper`.`favourites` (`email`, `sex`, `race`, `firstName`) VALUES (\'{CurrentEmail}\', \'Initialize\', \'Initialize\', \'Initialize\');";
                command.ExecuteNonQuery();
            }

            mysqlStatement = $"SELECT firstName, race, sex FROM favourites WHERE email = \"{CurrentEmail}\";";
            command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            dataAdapter.Update(dataTable);
        }

        /// <summary>
        /// add name to favourites
        /// </summary>
        /// <param name="name"></param>
        /// <param name="race"></param>
        /// <param name="sex"></param>
        public void AddNameToFavourites(string name, string race, string sex)
        {
            string mysqlStatement = $"INSERT INTO `writerhelper`.`favourites` (`email`, `firstName`, `race`, `sex`) VALUES (\'{CurrentEmail}\', \'{name}\', \'{race}\', \'{sex}\');";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
            dataTable.Clear();
        }

        /// <summary>
        /// check if a name exists in favourites
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public bool CheckIfAlreadyAdded(string name, int sex)
        {
            string Sex = "male";
            if (sex == 1)
            {
                Sex = "female";
            }
            string mysqlStatement = $"SELECT firstName FROM favourites WHERE email = \"{CurrentEmail}\" AND firstName = \'{name}\' AND sex = \'{Sex}\';";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                return true;
            }
            reader.Close();
            return false;
        }

        /// <summary>
        /// remove an item from the current favourite list
        /// </summary>
        /// <param name="name"></param>
        public void RemoveFavouriteName(string name)
        {
            string mysqlStatement = $"DELETE FROM favourites WHERE email = \'{CurrentEmail}\' AND firstName = \'{name}\'";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
        }
        public void AddFavouriteName(string name, string race, string sex)
        {
            string mysqlStatement = $"INSERT INTO `writerhelper`.`favourites` (`email`, `firstName`, `race`, `sex`) VALUES ('{CurrentEmail}','{name}', '{race}', '{sex}');";
            MySqlCommand command = new MySqlCommand(mysqlStatement, connection);
            command.ExecuteNonQuery();
        }

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
