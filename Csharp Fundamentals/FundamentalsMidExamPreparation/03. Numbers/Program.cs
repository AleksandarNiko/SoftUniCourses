using System.Collections.Generic;

namespace _03._Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int sum = 0;
            int average = 0;
            int counter = 0;

            if (sequence.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }
            for (int i=0; i<sequence.Count; i++)
            {
                sum += sequence[i];
            }
            average = sum / sequence.Count;

            List<int> numbers =new List<int>();
            for (int i=0;i<sequence.Count; i++)
            {
                if (sequence[i] > average)
                {
                    numbers.Add(sequence[i]);
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                var result = sequence.OrderByDescending(x => x).Where(x => x > average).Take(5).ToArray();

                Console.WriteLine(string.Join(" ", result));
            }

        }
    }
    }
//10 20 30 40 50