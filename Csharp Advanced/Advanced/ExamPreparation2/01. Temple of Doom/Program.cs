namespace TempleOfDoom
{
    public class Program
    {
         static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> substances = new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            List<int> challenges = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                int currentTool = tools.Peek();
                int currentSubstance = substances.Peek();
                int result = currentSubstance * currentTool;

                if (challenges.Contains(result))
                {
                    tools.Dequeue();
                    substances.Pop();
                    challenges.Remove(result);
                    if (challenges.Count == 0)
                    {
                        Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
                        break;
                    }
                }
                else
                {
                    tools.Enqueue(tools.Dequeue() + 1);
                    substances.Push(substances.Pop()-1);
                    if (substances.Peek() == 0)
                    {
                        substances.Pop();
                    }
                    if (substances.Count == 0)
                    {
                        Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
                        break;
                    }
                }
            }

            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (challenges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }

        }
    }
}
/*
2 4 6 8
11 3 5 7 9
24 28 18 30
   
13 7 4 22 11 15 20
3 2 1
12 10 5
   
 */