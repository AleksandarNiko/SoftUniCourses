namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //input
            string[]arr1=Console.ReadLine().Split().ToArray();
            string[]arr2=Console.ReadLine().Split().ToArray();
            //operation
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j=0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        Console.Write(arr1[i]+ " ");
                    }
                }
            }

            //output
        }
    }
}