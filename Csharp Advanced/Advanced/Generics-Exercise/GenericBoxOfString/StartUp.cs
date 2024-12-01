namespace GenericBoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < numOfLines; i++)
            {
                string line = Console.ReadLine();
                box.Add(line);
            }

            Console.WriteLine(box);
        }
    }
}
/*
2
life in a box
box in a life
 */