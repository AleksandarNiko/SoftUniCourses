// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
string input;
List<Student> students=new List<Student>();
while ((input=Console.ReadLine())!="end")
{
    string[] lineToken = input.Split();
    string firstName=lineToken[0];
    string lastName = lineToken[1];
    int age = int.Parse(lineToken[2]);
    string homeTown = lineToken[3];

    Student student = new Student();
    {
        student.FirstName = firstName;
        student.LastName = lastName;
        student.Age = age;
        student.HomeTown = homeTown;
    }
    students.Add(student);

}
string cityName=Console.ReadLine();
foreach (Student student in students)
{
    if (student.HomeTown == cityName)
    {
        Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
    }
}

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int Age { get; set; }

    public string HomeTown { get; set; }
}

