using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver:IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> caughtFish;
        private double competitionPoints;
        public bool hasHealthIssues;
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
                    throw new ArgumentException("Diver's name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int OxygenLevel
        {
            get
            {
                return oxygenLevel;
            }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                oxygenLevel = value;
            }
        }

        public IReadOnlyCollection<string> Catch
        {
            get
            {
                return  caughtFish.AsReadOnly();
            }
        }

        public double CompetitionPoints
        {
            get
            {
                return competitionPoints;
            }
            private set => competitionPoints = value;
        }

        public bool HasHealthIssues
        {
            get
            {
                return hasHealthIssues;
            }
            private set
            {
                hasHealthIssues= value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            this.caughtFish.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public void UpdateHealthStatus()
        {
            HasHealthIssues = !HasHealthIssues;
        }
        public abstract void RenewOxy();
        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {this.caughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }

        public Diver(string name, int oxygenLevel)
        {
            Name=name;
            OxygenLevel = oxygenLevel;
        }
    }
}
