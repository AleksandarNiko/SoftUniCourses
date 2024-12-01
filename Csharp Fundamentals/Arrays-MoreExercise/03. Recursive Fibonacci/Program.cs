namespace _03._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int number=int.Parse(Console.ReadLine());
            int[]sequence=new int[50];
            sequence[0] = 1;
            sequence[1] = 1;
            if (number > 2)
            {
                for (int i = 2; i < number; i++)
                {
                    sequence[i] = sequence[i - 1]+sequence[i-2];
                }
            }
            Console.WriteLine(sequence[number-1]);
        }
    }
}