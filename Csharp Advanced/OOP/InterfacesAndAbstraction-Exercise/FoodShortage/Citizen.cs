using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Citizen:IIdentifiable, IBirthable, IBuyer, IAge
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; set; }
        public DateTime Birthdate { get; private set; }
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public void BuyFood()
        {
            Food += 10;
        }
        public int Food { get; private set; }
    }
}
