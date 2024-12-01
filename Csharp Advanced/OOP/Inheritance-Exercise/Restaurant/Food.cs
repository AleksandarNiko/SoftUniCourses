namespace Restaurant
{
    public class Food : Product
    {
        private double grams;

        public Food(string name, decimal price, double grams)
            : base(name, price)
        {
            this.Grams = grams;
        }

        public virtual double Grams
        {
            get => this.grams;
            set => this.grams = value;
        }
    }
}
