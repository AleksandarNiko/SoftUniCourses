using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Lizard:Reptile
    {
        public string Name { get; set; }
        public Lizard(string name)
        : base(name)
        {
            this.Name = name;
        }
    }
}
