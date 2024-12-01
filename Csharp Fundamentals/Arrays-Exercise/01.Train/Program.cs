namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] arr = new int[n];
            //operations
            for (int i = 0; i < n; i++)
            {
                int numOfPeople = int.Parse(Console.ReadLine());
                arr[i] = numOfPeople;
                sum +=arr[i] ;
            }
            //output
            Console.WriteLine(string.Join(" ",arr));
            Console.WriteLine(sum);
        }

        }
    }
