using System.Globalization;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfElements = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < numOfElements; i++)
            {
                double currentElement = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture );
                box.Add(currentElement);
            }

            double valueToCompare = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine(box.Count(valueToCompare));
        }
    }
}
/*
3
7.13
123.22
42.78
7.55
 */