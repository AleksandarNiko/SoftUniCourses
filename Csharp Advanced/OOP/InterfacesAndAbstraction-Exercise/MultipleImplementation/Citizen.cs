using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen:IBirthable,IIdentifiable,IPerson
    {
        public string Birthdate { get; }
        public string Id { get; }
        public string Name { get; }
        public int Age { get; }

        public Citizen(string name,int age,string id,string birthdate)
        {
            Name=name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
    }
}
