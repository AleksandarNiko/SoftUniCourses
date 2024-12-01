using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public class Meat : Food
    {
        public override int Quantity { get; set; }
        public Meat(int quantity) : base(quantity)
        {

        }
    }
}
