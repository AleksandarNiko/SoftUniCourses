namespace GenericBoxOfInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < numOfLines; i++)
            {
                int line = int.Parse(Console.ReadLine());
                box.Add(line);
            }

            Console.WriteLine(box);
        }
    }
}
/*
1
1001
 */