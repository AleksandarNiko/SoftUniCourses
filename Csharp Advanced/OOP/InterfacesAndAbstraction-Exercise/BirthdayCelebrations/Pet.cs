using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Pet:IBirthable,IName
    {
        public DateTime Birthdate { get; private set; }
        public string Name { get; private set; }
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }
    }
}
