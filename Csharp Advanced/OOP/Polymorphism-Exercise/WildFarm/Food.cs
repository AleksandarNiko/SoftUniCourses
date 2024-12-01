using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Food:IFood
    {
        public abstract int Quantity { get; set; }

        public Food(int quantity)
        {
            Quantity = quantity;
        }
    }
}
