namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lineToken=Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int n = lineToken[0];
            int m = lineToken[1];

            HashSet<int> nNums= new HashSet<int>();
            HashSet<int> mNums= new HashSet<int>();

                for (int j = 0; j < n; j++)
                {
                    int nums1 = int.Parse(Console.ReadLine());
                    nNums.Add(nums1);
                }

                for (int k = 0; k < m; k++)
                {
                    int nums2=int.Parse(Console.ReadLine());
                    mNums.Add(nums2);
                }
                
            foreach (var nNum in nNums)
            {
                foreach (var mNum in mNums)
                {
                    if (nNum == mNum)
                    {
                        Console.Write(nNum+" ");
                    }
                }
            }

        }
    }
}
/*
2 2
1
3
1
5
 */