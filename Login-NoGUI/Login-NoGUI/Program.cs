using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_NoGUI
{
    class Program
    {
        public static Dictionary<string, User> users = new Dictionary<string, User>();
        public static string activeUser;

        static void Main(string[] args)
        {
            User u = new User("James", "Cairns", 1998); //Creates and adds a new user to the dictionary.

            MainMenu();
        }

        static void MainMenu()
        {
            activeUser = null;
            Console.WriteLine(@"Welcome to Vroxi2017!
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
Would you like to:
Login
Create User
Help
Exit
");
            Console.Write(": "); string ans = Console.ReadLine();
            while (true)
            {
                switch (ans)
                {
                    case "Login":
                        Login();
                        break;
                    case "Create User":
                        CreateUser();
                        break;
                    case "Help":
                        Help();
                        break;
                    case "Exit":
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Your input is incorrect please enter a correct option.");
                Console.Write(": "); ans = Console.ReadLine();
            }

        }

        static void CreateUser()
        {
            Console.WriteLine("Create User");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("Enter Username: "); string un = Console.ReadLine();
            while (users.ContainsKey(un))
            {
                Console.WriteLine("Error! That username already exists. Please choose another.");
                Console.Write("Enter Username: "); un = Console.ReadLine();
                if (!users.ContainsKey(un))
                {
                    break;
                }
            }
            Console.Write("Enter Password: "); string pw = Console.ReadLine();
            while (pw.Length < 8)
            {
                Console.WriteLine("Error! Please enter a password longer than 12 characters.");
                Console.Write("Enter Password: "); pw = Console.ReadLine();
                if (pw.Length > 8)
                {
                    break;
                }
            }
            Console.Write("Enter Birth Year: "); int by = int.Parse(Console.ReadLine());
            User u = new User(un,pw,by);
            MainMenu();
        }

        static void Login()
        {
            Console.Write("Username: "); string username = Console.ReadLine(); //Writes and reads on the same line. 
            Console.Write("Password: "); string password = Console.ReadLine(); //Gets the password and username.
            LoginCheck(username, password); //Moves onto the next method. With GUI once the Login button is clicked it will trigger this.
        }

        static void LoginCheck(string un, string pw)
        {
            if (!users.ContainsKey(un)) //Checks whether or not the username exists in the dictionary.
            {
                Console.WriteLine("Username does not exist.");
                Login();
            }
            if (pw != users[un].GetPassword()) //Checks whether or not the password is correct for the specified username.
            {
                Console.WriteLine("Incorrect password.");
                Login();
            }
            else //If the previous if statements passed then the password and username must be correct.
            {
                Console.WriteLine("You're In!");
                activeUser = un;
                TheConsole();
            }
        }

        static void Help()
        {
            Console.WriteLine(@"Help
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
To use commands once logged in type '/' and then
type the command. For example: /Help 

Command List
Help - Displays list of commands and what they do.
Menu - Returns to main menu and logs out.
Game - Loads the game. #Currently under construction.
Exit - Exits the program.");
            TheConsole();
        }

        static void TheConsole()
        {
            List<string> cmds = new List<string>();
            LoadCmds(cmds);
            while (true)
            {
                Console.Write(": "); string input = Console.ReadLine();
                if (cmds.Contains(input))
                {
                    switch (input)
                    {
                        case "/Help":
                            Help();
                            break;
                        case "/Menu":
                            MainMenu();
                            break;
                        case "/Game":
                            if (CheckLoginStatus())
                            {
                                Console.WriteLine("Loading Game...");
                                Console.ReadKey();
                                System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Steam\Steam.exe");
                                break;
                            }
                            if (!CheckLoginStatus())
                            {
                                Console.WriteLine("You are not logged in. Please log in.");
                                MainMenu();
                            }
                            break;
                        case "/Exit":
                            Environment.Exit(0);
                            break;
                    }
                }
                if (input.FirstOrDefault() == '/')
                {
                    Console.WriteLine("This command does not exist.");
                }
            }
        }

        static void LoadCmds(List<string> cmds)
        {
            cmds.Add("/Help");
            cmds.Add("/Menu");
            cmds.Add("/Game");
            cmds.Add("/Exit");
        }

        static bool CheckLoginStatus()
        {
            if (activeUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
    }
}
