namespace Restaurant.FoodProducts
{
    public class Fish : MainDish
    {

        public Fish(string name, decimal price)
            : base(name, price, 0)
        {

        }

        public override double Grams
        {
            get => 22;
        }
    }
}