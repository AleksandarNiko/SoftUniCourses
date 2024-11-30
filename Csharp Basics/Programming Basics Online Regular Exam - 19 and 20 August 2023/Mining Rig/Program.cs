using System;

namespace Mining_Rig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int videocard = int.Parse(Console.ReadLine());
            int prehodnik=int.Parse(Console.ReadLine());
            double tok=double.Parse(Console.ReadLine());
            double pechalba=double.Parse(Console.ReadLine());
            double totalPrice=1000+13*videocard+13*prehodnik;
            double pechalbaZaDenVideocard = pechalba - tok;
            double pechalbaZaDen = 13 * pechalbaZaDenVideocard;
            Console.WriteLine(totalPrice);
            Console.WriteLine(Math.Ceiling(totalPrice / pechalbaZaDen));
        }
    }
}
