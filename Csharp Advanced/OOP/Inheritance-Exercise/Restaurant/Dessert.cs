namespace Restaurant
{
    public class Dessert : Food
    {
        private double calorie;

        public Dessert(string name, decimal price, double grams, double calorie)
            : base(name, price, grams)
        {
            this.Calorie = calorie;
        }   

        public virtual double Calorie
        {
            get => this.calorie;
            set => this.calorie = value;
        }
    }
}
