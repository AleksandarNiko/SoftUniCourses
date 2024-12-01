namespace _02.RecursiveFactorial
{
    public class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine(Fact(num));
        }

        static int Fact(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            return num*Fact(num-1);
        }
    }
}
