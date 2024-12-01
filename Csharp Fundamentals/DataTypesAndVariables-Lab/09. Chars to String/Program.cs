namespace _09._Chars_to_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());
            char character2 = char.Parse(Console.ReadLine());
            char character3 = char.Parse(Console.ReadLine());
            List<char> text= new List<char>();
            text.Add(character);
            text.Add(character2);
            text.Add(character3);
            Console.WriteLine($"{string.Join("",text)}");
        }
    }
}