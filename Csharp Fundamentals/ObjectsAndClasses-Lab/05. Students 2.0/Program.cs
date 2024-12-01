using System.Runtime.ExceptionServices;

string input;
List<Student> students = new List<Student>();
while ((input = Console.ReadLine()) != "end")
{
    string[] lineToken = input.Split();
    string firstName = lineToken[0];
    string lastName = lineToken[1];
    int age = int.Parse(lineToken[2]);
    string homeTown = lineToken[3];

    Student student = new Student();
    {
        student.FirstName = firstName;
        student.LastName = lastName;
        student.Age = age;
        student.HomeTown = homeTown;

        int index = ValidateStudent(firstName, lastName, students);
        if (index != -1)
        {
            students[index].Age = age;
            students[index].HomeTown = homeTown;
            continue;
        }
        students.Add(student);

    }
}
    string cityName = Console.ReadLine();
    foreach (Student student in students)
    {
        if (student.HomeTown == cityName)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
        }
    }



static int ValidateStudent(string firstName, string lastName,List<Student>students)
{
    for (int i = 0; i < students.Count; i++)
    {
        if (students[i].FirstName == firstName && students[i].LastName == lastName)
        {
            return i;
        }
    }
    return -1;
}

class Student
{
     public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Age { get; set; }

    public string HomeTown { get; set; }
}







