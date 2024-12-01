namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int n = int.Parse(Console.ReadLine());
            string[]firstArr=new string[n];
            string[]secondArr=new string[n];
            bool isFirstSelected = true;
            //operation
            for (int i = 0; i < n; i++)
            {
                string numbers=Console.ReadLine();
                string[] numbersArr = numbers.Split();
                if (isFirstSelected)
                {
                    firstArr[i] = numbersArr[0];
                    secondArr[i] = numbersArr[1];
                }
                else
                {
                    firstArr[i] = numbersArr[1];
                    secondArr[i] = numbersArr[0];
                }
                isFirstSelected =! isFirstSelected;
            }

            //output
            Console.WriteLine(string.Join(" ",firstArr));
            Console.WriteLine(string.Join(" ",secondArr));
        }
    }
}