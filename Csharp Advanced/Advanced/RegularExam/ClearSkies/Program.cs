namespace ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] airspace = new char[n,n];

            int currentRow = 0;
            int currentCol = 0;

            int repearPoints = 0;
            int armour = 300;
            int enemies = CountEnemies(airspace, n);

            for (int i = 0; i < airspace.GetLength(0); i++)
            {
                char[] row = Console.ReadLine()!.ToCharArray();
                for (int j = 0; j < airspace.GetLength(1); j++)
                {
                    airspace[i, j] = row[j];
                    if (row[j] == 'J') 
                    {
                        currentRow = i;
                        currentCol = j;
                    }
                    else if (row[j] == 'E') enemies++; 
                }
            }

            while (true)
            {
                string command=Console.ReadLine();
                airspace[currentRow, currentCol] = '-';
                Direction direction = (Direction)Enum.Parse(typeof(Direction), command);
                switch (direction)
                {
                    case Direction.down:
                        if (!Move((int)(currentRow + 1), currentCol))
                        {
                            return;
                        }
                        break;
                    case Direction.up:
                        if (!Move((int)(currentRow - 1), currentCol))
                        {
                            return;
                        }

                        break;
                    case Direction.left:
                        if (!Move((int)(currentRow), currentCol-1))
                        {
                            return;
                        }

                        break;
                    case Direction.right:
                        if (!Move((int)(currentRow ), currentCol+1))
                        {
                            return;
                        }
                        break;
                    default: break;
                }
            }

            bool Move(int nextPositionRow, int nextPositionCol)
            {
                if (airspace[nextPositionRow, nextPositionCol] == 'R')
                {
                    armour = 300;
                }
                else if (airspace[nextPositionRow, nextPositionCol] == 'E')
                {
                    armour -= 100;
                    enemies--;
                }

                airspace[currentRow, currentCol] = '-';
                airspace[nextPositionRow, nextPositionCol] = 'J';
                currentRow = nextPositionRow;
                currentCol = nextPositionCol;

                if (armour == 0)
                {
                    Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentRow}, {currentCol}]!");
                    PrintAirspace(airspace,n);
                    return false;
                }
                else if (enemies == 0)
                {
                    Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");
                    PrintAirspace(airspace,n);
                    return false;
                }
                return true;
            }

            static void PrintAirspace(char[,] airspace, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(airspace[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            static int CountEnemies(char[,] airspace, int n)
            {
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (airspace[i, j] == 'E')
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        enum Direction
            {
                down,
                up,
                left,
                right
            }
        }
    }
/*
5
-R---
-J--E
-E---
--E-E
-R---
up
down
down
down
right
right
right
 */

