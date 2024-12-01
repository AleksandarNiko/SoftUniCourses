using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string input;

            while((input=Console.ReadLine()) != "END")
            {
                string[] lineToken = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = lineToken[0];
                switch (command)
                {
                    case "Push":
                        stack.Push(lineToken.Skip(1)
                            .Select(a => a.Split(",")
                                .First())
                            .ToArray());
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }
            }

            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
/*
Push 1, 2, 3, 4
Pop
Pop
END

Push 1, 2, 3, 4
Pop
Push 1
END
*/
