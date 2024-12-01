namespace _02._Center_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1=double.Parse(Console.ReadLine());
            double x2=double.Parse(Console.ReadLine());
            double y2=double.Parse(Console.ReadLine());

            double c1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double c2 = Math.Sqrt(x2 * x2 + y2 * y2);

            if (c1 > c2)
            {
                Print(x2, y2);
            }
            else if (c1 <= c2)
            {
                Print(x1, y1);
            }
        }

        private static void Print(double x, double y)
        {
            Console.WriteLine($"({x}, {y})");
        }
    }
    }
/*
2
4
-12*/