namespace SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                double squareRoot = Math.Sqrt(number);
                Console.WriteLine($"{squareRoot}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid number.");
            }

            finally
            {
                Console.WriteLine("Goodbye.");
            }

        }
    }
}
