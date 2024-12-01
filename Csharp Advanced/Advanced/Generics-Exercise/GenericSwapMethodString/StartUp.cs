namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfBoxes=int.Parse(Console.ReadLine());
            List<string> boxes=new List<string>();
            for (int i = 0; i < numOfBoxes; i++)
            {
                string line=Console.ReadLine();
                boxes.Add(line);
            }
            int[] indexes=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];
            Swap(boxes, firstIndex, secondIndex);

            foreach (var item in boxes)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }

        }

        public static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
/*
3
Peter
George
Swap me with Peter
0 2
 */