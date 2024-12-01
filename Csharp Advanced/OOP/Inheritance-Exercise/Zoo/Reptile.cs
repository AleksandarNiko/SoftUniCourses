using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Reptile:Animal
    {
        public string Name { get; set; }
        public Reptile(string name)
            :base(name)
        {
            this.Name = name;
        }
    }
}
