namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name)
            : base(name, 0, 0, 0)
        {
            this.Name = name;
        }

        public override double Grams
        {
            get => 250;
        }
        public override double Calorie
        {
            get => 1000;
        }
        public override decimal Price
        {
            get => 5m;
        }
    }
}