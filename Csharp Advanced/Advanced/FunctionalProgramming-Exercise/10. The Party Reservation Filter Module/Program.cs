namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> filters = new();

            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] lineToken = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                string command = lineToken[0];
                string filter = lineToken[1];
                string value = lineToken[2];

                if (command == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                }
                else
                {
                    filters.Remove(filter + value);
                }
            }

            foreach (var filter in filters)
            {
                people.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", people));


            static Predicate<string> GetPredicate(string filter, string value)
            {
                switch (filter)
                {
                    case "Starts with":
                        return p => p.StartsWith(value);
                    case "Ends with":
                        return p => p.EndsWith(value);
                    case "Length":
                        return p => p.Length == int.Parse(value);
                    case "Contains":
                        return p => p.Contains(value);
                    default:
                        return default;
                }
            }
        }
    }
}
/*
Peter Misha John
Add filter;Starts with;P
Add filter;Starts with;M
Remove filter;Starts with;M
Print
 */