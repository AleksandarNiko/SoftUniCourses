using static System.Net.Mime.MediaTypeNames;

namespace _01._Extract_Person_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = string.Empty;
                string age = string.Empty;
                string text = Console.ReadLine();

                int firstSeparatorIndexForName = text.IndexOf('@');
                int lastSeparatorIndexForName = text.IndexOf('|');

                int firstSeparatorIndexForAge = text.IndexOf('#');
                int lastSeparatorIndexForAge = text.IndexOf('*');
                if (firstSeparatorIndexForName != -1 && lastSeparatorIndexForName != -1 &&
                    lastSeparatorIndexForName > firstSeparatorIndexForName)
                {
                    name = text.Substring(firstSeparatorIndexForName + 1,
                        lastSeparatorIndexForName - firstSeparatorIndexForName - 1);
                }

                if (firstSeparatorIndexForAge != -1 && lastSeparatorIndexForAge != -1 &&
                    lastSeparatorIndexForAge > firstSeparatorIndexForAge)
                {
                    age = text.Substring(firstSeparatorIndexForAge + 1,
                        lastSeparatorIndexForAge - firstSeparatorIndexForAge - 1);
                }

                Console.WriteLine($"{name} is {age} years old.");
        }
    }
    }
}
/*
2
Here is a name @George| and an age #18*
Another name @Billy| #35* is his age
*/