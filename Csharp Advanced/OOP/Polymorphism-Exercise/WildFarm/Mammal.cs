using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Mammal:Animal,IMammal
    {
        protected Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }
    }
}
