using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your username");
                Login thisLogin = LogThisGuyIn();
                //database access code goes here

                string nextAction = string.Empty;
                while (nextAction != "X")
                {
                    Console.WriteLine("What would you like to do");
                    //Put a bunch of options here
                    Console.WriteLine("eXit the game");
                    Console.WriteLine();
                    nextAction = Console.ReadLine();
                }

            }

            Console.ReadLine();
        }

        private static Login LogThisGuyIn()
        {
            using (PinkDragonEntities database = new PinkDragonEntities())
            {
                var username = Console.ReadLine();
                var thisLogin = database.Logins.FirstOrDefault(l => l.Username == username);

                if (thisLogin != null)
                {
                    Console.WriteLine("Welcome " + username);
                    Console.WriteLine("Password?");
                    if (thisLogin.Password == Console.ReadLine())
                    {
                        Console.WriteLine("You are correct!");
                        thisLogin.LastLoginDate = DateTime.Now;
                        database.SaveChanges();
                    }

                }
                else
                {
                    Console.WriteLine("I don't know you!");
                    Console.WriteLine("Would you like to play? (Y/N)");
                    if (Console.ReadLine() == "Y")
                    {
                        Console.WriteLine("Enter a password");
                        //create a new login
                        string password = Console.ReadLine();

                        var newLogin = new Login();
                        newLogin.Username = username;
                        newLogin.Password = password;
                        newLogin.LastLoginDate = DateTime.Now;

                        database.Logins.Add(newLogin);
                        database.SaveChanges();
                        Console.WriteLine("Welcome to the game");

                    }
                }
                return thisLogin;
            }
        }
    }
}

