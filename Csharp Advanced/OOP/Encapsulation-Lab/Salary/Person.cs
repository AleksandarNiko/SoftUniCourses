﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

        public Person(string firstName, string lastName, int age,decimal salary)
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
                Salary += Salary * percentage/100;
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
