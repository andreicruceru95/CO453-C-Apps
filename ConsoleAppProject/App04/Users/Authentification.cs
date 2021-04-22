using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppProject.App04.Users
{
    /// <summary>
    /// An Authentfication system created to manage the access to application for new and old users.
    /// </summary>    
    public class Authentification
    {
        #region Fields

        private static Authentification instance;
        public static string UsersFile = Path.Combine
            (@"C:\Users\andre\source\repos\andreicruceru95\CO453-C-Apps\ConsoleAppProject\App04\Users", "Users.bin");
        private List<object> UsersList = new List<object>();
        private User CurrentUser;

        #endregion

        #region Properties
        public static Authentification Instance
        {
            get
            {
                if (instance == null)
                    instance = new Authentification();
                return instance;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Main method.
        /// </summary>
        /// <returns></returns>
        public object Run()
        {
            GetUserChoice();

            if (CurrentUser != null) 
                return CurrentUser;
            else
            {
                ConsoleHelper.PrintString(IndentLevel.Level2, "You must login as a user to use the app. Login or create a new Account!\n");

                return Run();
            }
        }        

        /// <summary>
        /// Retrieve the user's choice.
        /// </summary>
        private void GetUserChoice()
        {
            int choice = ChoiceList.Instance.GetOptionList("\tLogin or create a new account!","authentification");
            string username = ConsoleHelper.InputString("\tEnter Username:");
            string password = ConsoleHelper.InputString("\tEnter Password");

            if (choice == 1)
                CurrentUser = Login(username, password) as User;

            else if(choice == 2) CreateNew(username, password);
        }

        /// <summary>
        /// Manage existing users access to application.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public object Login(string username, string password)
        {
            if (File.Exists(UsersFile))
            {
                UsersList = Streamer.ReadFile(UsersFile);                
            }
            foreach (User user in UsersList)
            {
                if (user.ValidateLogin(username, password))
                {
                    ConsoleHelper.PrintString(IndentLevel.Level2, $"Welcome, {username}\n");

                    return user;
                }
            }
            ConsoleHelper.PrintString(IndentLevel.Level2, "Username not found!\n");            
            return null;
        }

        /// <summary>
        /// Manage new users access to application.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void CreateNew(string username, string password)
        {
            List<string> usernames = new List<string>();

            if (File.Exists(UsersFile))
            {
                UsersList = Streamer.ReadFile(UsersFile);
                // create system admin user
                //UsersList.Clear();
                //UsersList.Add(new User("System", "123456"));
                //Streamer.SaveFile(UsersList, UsersFile);
            }
            foreach (User user in UsersList)
            {
                usernames.Add(user.Username);
            }
            if(!usernames.Contains(username))
            {
                if (password.Length < 3 && password.Length < 10)
                    ConsoleHelper.PrintString(IndentLevel.Level2, "Password must be longer than 3 characters and less than 10 characters!\n");
                else
                {
                    UsersList.Add(new User(username, password));
                    ConsoleHelper.PrintString(IndentLevel.Level2, $"New Acount {username} : {password} created!\n");
                    Streamer.SaveFile(UsersList, UsersFile);
                    return;
                }
            }
            else
                ConsoleHelper.PrintString(IndentLevel.Level2, "Username already exists! Try again!");
        }
        #endregion
    }
}
