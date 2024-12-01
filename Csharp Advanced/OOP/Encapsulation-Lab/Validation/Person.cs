using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public string LastName {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                if (value <=0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
            }
        }
        public decimal Salary {
            get
            {
                return this.salary;
            }
            private set
            {
                if (value < 650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }
            }
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += ((Salary * percentage) / 200);
            }
            else
            {
                Salary += Salary * percentage / 100;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{FirstName} {LastName} receives {Salary:F2} leva.");
            return sb.ToString();
        }
    }
}
