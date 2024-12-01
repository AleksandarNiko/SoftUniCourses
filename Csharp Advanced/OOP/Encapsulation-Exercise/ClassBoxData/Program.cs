namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new(length, width, height);
                Console.WriteLine(box.ToString());
            }
           catch (ArgumentException exception)
          {
                Console.WriteLine(exception.Message);
           }
        }
    }
}
/*
2
3
4

2
-3
4
 */
