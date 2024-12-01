using System;
using System.Globalization;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username=Console.ReadLine();
            string password="";
            for (int i = username.Length-1;i>=0; i--)
            {
                password += username[i];
            }
            int attemps = 0;
            while (attemps < 4)
            {
                string inputPassword = Console.ReadLine();
                attemps++;
                if (inputPassword==password)
                {
                    Console.WriteLine($"User {username} logged in.");break;
                }
                else if( attemps==4)
                {
                    Console.WriteLine($"User {username} blocked!");
                }
                else if (inputPassword!=password)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

            }
        }
    }
}
