namespace _03._Memory_Game
{
    internal class Program
    {
 /*
1 1 2 2 3 3 4 4 5 5
1 0
-1 0
1 0
1 0
1 0
end
 */
        static void Main(string[] args)
        {
            List<string> symbols = Console.ReadLine().Split().ToList();
            int moveCounter = 0;
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                int[] lineToken = input.Split(' ').Select(int.Parse).ToArray();
                int index1 = lineToken[0];
                int index2 = lineToken[1];
                moveCounter++;
                if ((index1 == index2 ||
                (index1 < 0 || index1 >= symbols.Count) ||
                (index2 < 0 || index2 >= symbols.Count)))
                {
                    string newElement = $"-{moveCounter}a";
                    List<string> newElements = new List<string>() { newElement, newElement };
                    int middleIndex = symbols.Count / 2;
                    symbols.InsertRange(middleIndex, newElements);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (symbols[index1] == symbols[index2])
                    {
                        string element = symbols[index1];
                        Console.WriteLine($"Congrats! You have found matching elements - {element}!");
                    
                        if (index1 > index2)
                        {                 
                            symbols.RemoveAt(index2); 
                            symbols.RemoveAt(index1 - 1);
                        }
                        else if(index2>index1)
                        {
                            symbols.RemoveAt(index1);
                            symbols.RemoveAt(index2-1);
                            
                        }
                    }
                    else if (symbols[index1] != symbols[index2])
                    {
                        Console.WriteLine("Try again!");
                    }
                    if (symbols.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moveCounter} turns!");
                        break;
                    }
                }
            }
                if (symbols.Count != 0)
                {
                    Console.WriteLine("Sorry you lose :(");
                    Console.WriteLine(string.Join(" ", symbols));
                }
            }
        }
    
}
    
