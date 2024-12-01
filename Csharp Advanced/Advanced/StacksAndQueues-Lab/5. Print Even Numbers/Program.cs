namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input=Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue=new Queue<int>(input);
            
            while (queue.Count > 0)
            {
                int currentNumber = queue.Dequeue();
                if (currentNumber % 2 == 0)
                {
                    Console.Write(currentNumber);
                    if (queue.Count > 0)
                    {
                        Console.Write(", ");
                    }
                }
            }
        }
    }
}
//1 2 3 4 5 6