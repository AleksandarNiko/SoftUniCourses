using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes
{
    public class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MinAge, MaxAge)]
        public int Age { get; private set; }
    }
}
