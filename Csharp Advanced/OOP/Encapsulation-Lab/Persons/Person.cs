using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set;}
        public int Age { get; private set; }

        public Person(string firstName,string lastName,int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{FirstName} {LastName} is {Age} years old.");
            return sb.ToString();
        }
    }
}
