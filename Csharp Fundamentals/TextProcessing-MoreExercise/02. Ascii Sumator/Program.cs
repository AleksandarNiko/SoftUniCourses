namespace _02._Ascii_Sumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char c = char.Parse(Console.ReadLine());
            char c2= char.Parse(Console.ReadLine());
            string text= Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] > c && text[i] < c2)
                {
                    sum += text[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
/*
.
@
dsg12gr5653feee5
*/