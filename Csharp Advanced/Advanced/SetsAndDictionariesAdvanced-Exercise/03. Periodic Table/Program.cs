namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            HashSet<string> elements= new HashSet<string>();

            for (int i = 0; i < num; i++)
            {
                string[] lineToken = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < lineToken.Length; j++)
                {
                    elements.Add(lineToken[j]);
                }
            }

            elements = elements.OrderBy(x => x).ToHashSet();
            foreach (var element in elements)
            {
                Console.Write(element+" ");
            }
        }
    }
}
/*
3
Ge Ch O Ne
Nb Mo Tc
O Ne
 */