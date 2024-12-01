namespace _06._Student_Academy
{
    class Student
    {
        public  string  Name { get; set; }
        public  List<decimal> Grades { get; set; }

        public Student(string name) 
        {
            Name = name;
            Grades = new List<decimal>();            
        }
        public override string ToString()
        {
            return $"{Name} -> {Grades.Average():f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Student> students= new Dictionary<string,Student>();
            int pairOfRows=int.Parse(Console.ReadLine());
            for (int i = 0; i < pairOfRows; i++)
            {
                string name=Console.ReadLine();
                decimal grade=decimal.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new Student(name));
                }
                students[name].Grades.Add(grade); 
            }
            var filteredStudents = students.Where(x => x.Value.Grades.Average() >= 4.50m);
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student.Value);
            }
        }
    }
}
/*
5
John
5,5
John
4,5
Alice
6
Alice
3
George
5
*/