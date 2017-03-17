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

        static void Main(string[] args)
        {
            User u = new User("James", "Cairns"); //Adds a new user to the dictionary.

            Console.Write("Username: "); string username = Console.ReadLine(); //Writes and reads on the same line. 
            Console.Write("Password: "); string password = Console.ReadLine(); //Gets the password and username.
            LoginClicked(username, password); //Moves onto the next method. With GUI once the Login button is clicked it will trigger this.
        }

        static void LoginClicked(string un, string pw)
        {
            if (!users.ContainsKey(un)) //Checks whether or not the username exists in the dictionary.
            {
                Console.WriteLine("Username does not exist.");
                return;
            }
            if (pw != users[un].GetPassword()) //Checks whether or not the password is correct for the specified username.
            {
                Console.WriteLine("Incorrect password.");
                return;
            }
            else //If the previous if statements passed then the password and username must be correct.
            {
                Console.WriteLine("You're In!");
                Console.ReadKey();
            }
        }
    }
}
