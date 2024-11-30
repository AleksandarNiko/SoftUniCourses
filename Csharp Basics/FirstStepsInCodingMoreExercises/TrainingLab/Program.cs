using System;

namespace TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w=double.Parse(Console.ReadLine());
            double h=double.Parse(Console.ReadLine());
            double bura = Math.Floor((h - 1) / 0.7);
            double redove = Math.Floor(w / 1.2);
            double result = (bura * redove) - 3;
            Console.WriteLine(result);
        }
    }
}
