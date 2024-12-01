namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsOnGreen=int.Parse(Console.ReadLine());
            Queue<string> carsQueue=new Queue<string>();
            int passedCount = 0;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command=="green")
                {
                    for (int i = 0; i < carsOnGreen; i++)
                    {
                        if (carsQueue.Count == 0)
                        {
                            break;
                        }
                        var car = carsQueue.Dequeue();
                        Console.WriteLine($"{car} passed!");
                        passedCount++;
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
            }
            Console.WriteLine($"{passedCount} cars passed the crossroads.");

        }
    }
}
