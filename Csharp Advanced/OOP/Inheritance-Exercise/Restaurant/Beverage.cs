﻿namespace Restaurant
{
    public class Beverage : Product
    {
        private double milliliters;

        public Beverage(string name, decimal price, double milliliters)
            : base(name, price)
        {
            this.Milliliters = milliliters;
        }

        public virtual double Milliliters
        {
            get => this.milliliters;
            set => this.milliliters = value;
        }
    }
}
