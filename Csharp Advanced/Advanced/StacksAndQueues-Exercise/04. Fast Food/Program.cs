namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuant=int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> ordersQueue=new Queue<int>(orders);
            Console.WriteLine(orders.Max());
            while (ordersQueue.Any() )
            {
                if (foodQuant >= ordersQueue.Peek())
                {
                    foodQuant-=ordersQueue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}" );
                    return;
                }
            }          
            Console.WriteLine("Orders complete");
        }
    }
}
/*
348
20 54 30 16 7 9
*/
