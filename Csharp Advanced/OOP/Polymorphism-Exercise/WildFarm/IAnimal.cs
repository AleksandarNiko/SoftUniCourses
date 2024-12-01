using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }
        public void FeedIt(Food food);
        public string ProduceSound();
    }
}
