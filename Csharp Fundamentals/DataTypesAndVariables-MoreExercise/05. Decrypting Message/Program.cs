namespace _05._Decrypting_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte key = byte.Parse(Console.ReadLine());
            byte numberOfLines = byte.Parse(Console.ReadLine());
            string sum = "";
            while (numberOfLines > 0)
           {
                sum += ((char)(char.Parse(Console.ReadLine()) + key)).ToString();

                numberOfLines--;
           }

            Console.WriteLine(sum);
        }
    }
}