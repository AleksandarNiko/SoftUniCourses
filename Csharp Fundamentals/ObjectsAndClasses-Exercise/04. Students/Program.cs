namespace _04._Students
{
    class Student
    {
        public  string FirstName { get; set; }
        public string LastName { get; set; }
        public  decimal Grade { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:F2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int countStudents=int.Parse(Console.ReadLine());
            List <Student> students = new List<Student>();
            for (int i=0; i<countStudents; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                string firstName = lineToken[0];
                string lastName = lineToken[1];
                decimal grade = decimal.Parse(lineToken[2]);
                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Grade = grade
                };
                students.Add(student);
            }
            students=students.OrderByDescending(x=>x.Grade).ToList();
            Console.WriteLine(string.Join("\n",students));
        }
    }
}
