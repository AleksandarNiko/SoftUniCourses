namespace _06._Reversed_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char characher = char.Parse(Console.ReadLine());
            char characher2 = char.Parse(Console.ReadLine());
            char characher3 = char.Parse(Console.ReadLine());
            List<char> chars = new List<char>();
            chars.Add(characher);
            chars.Add(characher2);
            chars.Add(characher3);
            chars.Reverse();
            Console.WriteLine(string.Join(" ",chars));
        }
    }
}