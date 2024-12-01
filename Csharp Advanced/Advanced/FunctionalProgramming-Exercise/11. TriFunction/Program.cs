namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            Func<string, int, bool> checkEqualOrLargerNameSum = (name, sum) =>
                {
                    int charsSum = name.Sum(ch => ch);

                    return charsSum >= sum;
                };

            Func<string[], int, Func<string, int, bool>, string> getFirstName = (names, sum, match) =>
                {
                    foreach (var name in names)
                    {
                        if (match(name, sum))
                        {
                            return name;
                        }
                    }

                    return null;
                };

            string foundName = getFirstName(names, sum, checkEqualOrLargerNameSum);

            Console.WriteLine(foundName);
        }
    }
}
