using System;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            int end = int.Parse(Console.ReadLine());
            HashSet<int> deviders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToHashSet();
            int[] nums = Enumerable.Range(1, end).ToArray();

            foreach (int devider in deviders)
            {
                predicates.Add(n=>n%devider==0);
            }

            foreach (int num in nums)
            {
                bool isValid = true;
                foreach (var pred in predicates)
                {
                    if (!pred(num))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
/*
10
1 1 1 2
 */
