namespace _12._Refactor_Special_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            
            bool toe = false;
            for (int i = 1; i <= nums; i++)
            {
                int currentNum = i;
                int obshto = 0;
                
                while (i > 0)
                {
                    obshto += i % 10;
                    i = i / 10;
                }
                toe = (obshto == 5) || (obshto == 7) || (obshto == 11);
                Console.WriteLine("{0} -> {1}", currentNum, toe);
                i = currentNum;
            }

        }
    }
}