namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = lineToken[0];
                decimal grade= decimal.Parse(lineToken[1]);

                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<decimal>());
                }
                students[name].Add(grade);
            }

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(' ', item.Value.Select(grade => grade.ToString("F2")))} (avg: {item.Value.Average():f2})");
            }
        }
    }
}
/*
7
John 5,20
Maria 5,50
John 3,20
Maria 2,50
Sam 2,00
Maria 3,46
Sam 3,00
 */