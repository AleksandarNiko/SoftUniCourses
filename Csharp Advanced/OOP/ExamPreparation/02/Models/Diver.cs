namespace NauticalCatchChallenge.Models
{
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Utilities.Messages;
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> @catch;
        private bool hasHealthIssues;
        private double competitionPoints;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            @catch = new List<string>();
            competitionPoints = 0;
            hasHealthIssues = false;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.DiversNameNull));
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get => oxygenLevel;
            protected set
            {
                oxygenLevel = Math.Max(value, 0);
            }
        }

        public IReadOnlyCollection<string> Catch => @catch.AsReadOnly();
        public double CompetitionPoints => Math.Round(competitionPoints, 1);
        public bool HasHealthIssues => hasHealthIssues;


        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            @catch.Add(fish.Name);
            competitionPoints += Math.Round(fish.Points, 1, MidpointRounding.AwayFromZero);
        }

        public abstract void Miss(int timeToCatch);

        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            hasHealthIssues = !hasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {Catch.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
