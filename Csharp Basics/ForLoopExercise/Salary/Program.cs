using System;

namespace Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary=double.Parse(Console.ReadLine());
            double fine = 0;
            for (int i = 0; i < n && salary>fine; i++)
            {
                string site=Console.ReadLine();
                if (site == "Facebook") { fine += 150; }
                else if(site == "Instagram") { fine += 100; }
                else if (site == "Reddit") { fine += 50; }
            }
            if(fine >=salary) { Console.WriteLine($"You have lost your salary."); }
            else { Console.WriteLine(salary-fine); }
        }
    }
}
