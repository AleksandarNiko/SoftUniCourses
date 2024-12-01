namespace NauticalCatchChallenge.Models
{
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Utilities.Messages;
    public abstract class Fish : IFish
    {
        private string name;
        private double points;
        private int timeToCatch;

        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            this.timeToCatch = timeToCatch;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.FishNameNull));
                }
                name = value;
            }
        }

        public double Points
        {
            get => points;
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.PointsNotInRange));
                }
                points = value;
            }
        }

        public int TimeToCatch => timeToCatch;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
