using System;
using System.Collections.Generic;
using System.Linq;
namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> hand1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> hand2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (hand1.Count > 0 && hand2.Count > 0)
            {
                int playerOneCard = hand1[0];
                int playerTwoCard = hand2[0];

                if (playerOneCard > playerTwoCard)
                {
                    hand1.RemoveAt(0);
                    hand2.RemoveAt(0);
                    hand1.Add(playerTwoCard);
                    hand1.Add(playerOneCard);
                }
                else if (playerTwoCard > playerOneCard)
                {
                    hand1.RemoveAt(0);
                    hand2.RemoveAt(0);
                    hand2.Add(playerOneCard);
                    hand2.Add(playerTwoCard);
                }
                else
                {
                    hand1.RemoveAt(0);
                    hand2.RemoveAt(0);
                }
            }
            
                if (hand1.Count > 0)
                {
                    Console.WriteLine($"First player wins! Sum: {Sum(hand1)}");
                }
                else if (hand2.Count > 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {Sum(hand2)}");
                }
                else
                {
                    Console.WriteLine("No player wins! Sum: 0");
                }
            }
            static int Sum(List<int> list)
            {
                int sum = 0;
                foreach (int item in list)
                {
                    sum += item;
                }

                return sum;
            }
        }
    }

