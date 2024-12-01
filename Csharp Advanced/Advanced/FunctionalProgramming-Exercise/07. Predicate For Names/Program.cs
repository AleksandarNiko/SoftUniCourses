namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Action<string[], Predicate<string>> print = (names, match) =>
            {
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            print(names,n=>n.Length<=length);
        }
    }
}
/*
4
Karl Anna Kris Yahto
 */
