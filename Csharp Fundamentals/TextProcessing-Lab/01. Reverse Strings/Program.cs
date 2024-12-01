namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string word;
           
            while ((word = Console.ReadLine()) != "end")
            {
                string result = "";
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    result += word[i];
                }
                Console.WriteLine($"{word} = {result}");
            }

            
            

        }
    }
}
/*
helLo
Softuni
bottle
end
*/