namespace _04.SetCover
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] universe = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int numSets = int.Parse(Console.ReadLine());
            List<HashSet<int>> sets = new List<HashSet<int>>();

            for (int i = 0; i < numSets; i++)
            {
                int[] setElements = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                sets.Add(new HashSet<int>(setElements));
            }

            HashSet<int> elements = new HashSet<int>(universe);
            List<HashSet<int>> result = new List<HashSet<int>>();

            while (elements.Count > 0)
            {
                HashSet<int> bestSet = null;
                int maxIntersect = 0;

                foreach (var set in sets)
                {
                    HashSet<int> intersection = new HashSet<int>(elements);
                    intersection.IntersectWith(set);

                    if (intersection.Count > maxIntersect)
                    {
                        maxIntersect = intersection.Count;
                        bestSet = set;
                    }
                }

                result.Add(bestSet);
                elements.ExceptWith(bestSet);
            }

            Console.WriteLine($"Sets to take ({result.Count}):");
            foreach (var set in result)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }
    }
}
/*
1, 2, 3, 4, 5
4
1, 2, 3, 4, 5
2, 3, 4, 5
5
3
   
 */