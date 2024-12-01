namespace Froggy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stones=Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
//1, 2, 3, 4, 5, 6, 7, 8
