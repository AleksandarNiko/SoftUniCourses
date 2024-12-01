namespace MouseInTheKitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            string[,] cupboard = new string[rows, cols];
            int mouseRow = -1;
            int mouseCol = -1;
            int totalCheeseNumber = 0;


            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    cupboard[row, col] = line[col].ToString();

                    if (line[col].ToString() == "M")
                    {
                        mouseRow = row;
                        mouseCol = col;
                        cupboard[mouseRow, mouseCol] = "*";
                    }
                    if (cupboard[row, col] == "C")
                    {
                        totalCheeseNumber++;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "danger")
            {
                if ((input == "left" && mouseCol == 0) ||
                   (input == "right" && mouseCol == cupboard.GetLength(1) - 1) ||
                   (input == "up" && mouseRow == 0) ||
                   (input == "down" && mouseRow == cupboard.GetLength(0) - 1))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }
                else
                {
                    if ((input == "left" && cupboard[mouseRow, mouseCol - 1] == "@") ||
                        (input == "right" && cupboard[mouseRow, mouseCol + 1] == "@") ||
                        (input == "up" && cupboard[mouseRow - 1, mouseCol] == "@") ||
                        (input == "down" && cupboard[mouseRow + 1, mouseCol] == "@"))
                    {
                        continue;
                    }
                    else
                    {
                        if (input == "left")
                        {
                            mouseCol--;
                        }
                        else if (input == "right")
                        {
                            mouseCol++;
                        }
                        else if (input == "up")
                        {
                            mouseRow--;
                        }
                        else if (input == "down")
                        {
                            mouseRow++;
                        }

                        if (cupboard[mouseRow, mouseCol] == "C")
                        {
                            totalCheeseNumber--;
                            cupboard[mouseRow, mouseCol] = "*";
                            if (totalCheeseNumber == 0)
                            {
                                cupboard[mouseRow, mouseCol] = "M";
                                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                break;
                            }
                            continue;
                        }
                        if (cupboard[mouseRow, mouseCol] == "T")
                        {
                            Console.WriteLine("Mouse is trapped!");
                            break;
                        }
                    }
                }
            }
            if (input == "danger")
            {
                Console.WriteLine("Mouse will come back later!");
            }

            cupboard[mouseRow, mouseCol] = "M";

            for (int i = 0; i < cupboard.GetLength(0); i++)
            {
                for (int j = 0; j < cupboard.GetLength(1); j++)
                {
                    Console.Write(cupboard[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
/*
5,5
**M**
T@@**
CC@**
**@@*
**CC*
left
down
left
down
down
down
right
danger

   
 */