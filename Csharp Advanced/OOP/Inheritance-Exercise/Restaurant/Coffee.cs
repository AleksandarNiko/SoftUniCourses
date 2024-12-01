namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private double caffeine;

        public Coffee(string name, double caffeine)
            : base(name, 0, 0)
        {
            this.Caffeine = caffeine;
        }

        public override double Milliliters
        {
            get => 50;
        }

        public override decimal Price
        {
            get => 3.50m;
        }
        public double Caffeine
        {
            get => this.caffeine;
            set => this.caffeine = value;
        }
    }
}
