using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Bear:Mammal
    {
        public string Name { get; set; }
        public Bear(string name)
        :base(name)
        {
            this.Name = name;
        }
    }
}
