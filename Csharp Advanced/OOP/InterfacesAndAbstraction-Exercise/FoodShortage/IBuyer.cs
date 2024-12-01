using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public interface IBuyer
    {
        string Name { get; }
        void BuyFood();
        int Food { get; }
    }
}
