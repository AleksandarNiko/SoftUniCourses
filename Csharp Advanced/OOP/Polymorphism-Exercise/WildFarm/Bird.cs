﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm
{
    public abstract class Bird:Animal,IBird
    {
        private double wingSize;

        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize
        {
            get => wingSize;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException();
                }

                wingSize = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.WingSize}, {base.Weight}, {base.FoodEaten}]");
            return $"{base.ToString()} {sb}";
        }
    }
}
