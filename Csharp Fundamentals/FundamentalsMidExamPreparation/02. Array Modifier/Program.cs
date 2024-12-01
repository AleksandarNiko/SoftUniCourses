namespace _02._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string input=string.Empty;
            while (((input=Console.ReadLine())!="end"))
            {
                string[] lineToken = input.Split();
                string command = lineToken[0];
                if (command == "swap")
                {
                    int index1 = int.Parse(lineToken[1]);
                    int index2 = int.Parse(lineToken[2]);
                    int temp = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = temp;
                }
                if(command =="multiply")
                {
                    int index1 = int.Parse(lineToken[1]);
                    int index2 = int.Parse(lineToken[2]);
                    numbers[index1] *= numbers[index2];
                }
                if (command == "decrease")
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i]=numbers[i]-1;
                    }
                }
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
/*
23 -2 321 87 42 90 -123
swap 1 3
swap 3 6
swap 1 0
multiply 1 2
multiply 2 1
decrease
end
*/