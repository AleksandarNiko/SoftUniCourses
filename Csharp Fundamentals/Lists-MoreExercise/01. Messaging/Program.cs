namespace _01._Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers=Console.ReadLine().Split().Select(int.Parse).ToList();
            List<char> str = new List<char>();
            str.AddRange(Console.ReadLine());
            for (int  i =0; i<numbers.Count;  i++)
            {
                int sum = 0;
                while (numbers[i] != 0)
                {
                    sum += numbers[i] % 10;
                    numbers[i] /= 10;
                }
                int times = sum / str.Count;
                sum = sum - times * str.Count;
                Console.Write(str[sum]);
                str.RemoveAt(sum);
            }
        }
    }
}
/*
9992 562 8933
This is some message for you
*/