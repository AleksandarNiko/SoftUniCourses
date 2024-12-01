using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private const double DefaultCaloriesPerGram = 2.0;
        private readonly Dictionary<string, double> toppingTypesCalories;

        private string toppingType;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            toppingTypesCalories = new Dictionary<string, double>
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 },
            };

            ToppingType = toppingType;
            Weight = weight;
        }


        public string ToppingType
        {
            get => toppingType;

            private set
            {
                if (!toppingTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public double Weight
        {
            get => weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{ToppingType} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }


        public double Calories => Weight * toppingTypesCalories[toppingType.ToLower()] * 2;
    }
}
