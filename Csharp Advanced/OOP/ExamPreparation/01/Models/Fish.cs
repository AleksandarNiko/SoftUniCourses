using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish:IFish
    {
        private string name;
        private double points;
        private int timeToCatch;
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish name should be determined.");
                }
                name = value;
            }
        }

        public double Points
        {
            get
            {
                return points;
            }
            private set
            {
                if (!(value >= 1 && value <= 10))
                {
                    throw new ArgumentException("Points must be a numeric value, between 1 and 10.");
                }
                points = value;
            }
        }

        public int TimeToCatch
        {
            get
            {
                return timeToCatch;
            }
            private set
            {
                timeToCatch = value;
            }
        }

        public Fish(string name,double points,int timeToCatch)
        {
            Name=name;
            Points=points;
            TimeToCatch=timeToCatch;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
