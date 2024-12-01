namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity=int.Parse(Console.ReadLine());
            Stack<int> delivery=new Stack<int>(clothes);
            int racksUsed = 1;
            int currentRackCapacity = capacity;
            int sum = 0;
            while(delivery.Any())
            {
                if (delivery.Peek() <= currentRackCapacity)
                {
                    currentRackCapacity -= delivery.Pop();
                }
                else
                {
                    racksUsed++;
                    currentRackCapacity= capacity;
                }
            }
            Console.WriteLine(racksUsed);
        }
    }
}
/*
5 4 8 6 3 8 7 7 9
16

1 7 8 2 5 4 7 8 9 6 3 2 5 4 6
20
 */
