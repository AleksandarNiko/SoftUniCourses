namespace NauticalCatchChallenge.Core
{
    using NauticalCatchChallenge.Core.Contracts;
    using NauticalCatchChallenge.Models;
    using NauticalCatchChallenge.Models.Contracts;
    using NauticalCatchChallenge.Repositories;
    using NauticalCatchChallenge.Repositories.Contracts;
    using NauticalCatchChallenge.Utilities.Messages;
    using System.Text;
    public class Controller : IController
    {
        private IRepository<IDiver> divers;
        private IRepository<IFish> fishes;

        public Controller()
        {
            divers = new DiverRepository();
            fishes = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }
            if (fishes.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);

            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            IFish fish = fishes.GetModel(fishName);

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch && !isLucky)
            {
                diver.Miss(fish.TimeToCatch);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else
            {
                diver.Hit(fish);

                if (diver.OxygenLevel == 0)
                {
                    diver.UpdateHealthStatus();
                }
                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }

        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var d in divers.Models.Where(x => x.HasHealthIssues == false).OrderByDescending(x => x.CompetitionPoints).ThenByDescending(x => x.Catch.Count).ThenBy(x => x.Name))
            {
                sb.AppendLine(d.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            string result = string.Empty;

            if (diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver))
            {
                result = string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }
            else if (divers.GetModel(diverName) != null)
            {
                result = string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
            }
            else
            {
                IDiver diver;

                if (diverType == nameof(FreeDiver))
                {
                    diver = new FreeDiver(diverName);
                }
                else
                {
                    diver = new ScubaDiver(diverName);
                }

                divers.AddModel(diver);
                result = string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
            }

            return result.Trim();
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var fishName in diver.Catch)
            {
                IFish currFish = fishes.GetModel(fishName);
                sb.AppendLine(currFish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            int counter = 0;

            foreach (var d in divers.Models.Where(x => x.HasHealthIssues == true))
            {
                counter++;
                d.UpdateHealthStatus();
                d.RenewOxy();
            }

            return string.Format(OutputMessages.DiversRecovered, counter);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            string result = string.Empty;

            if (fishType != nameof(ReefFish) &&
                fishType != nameof(PredatoryFish) &&
                fishType != nameof(DeepSeaFish))
            {
                result = string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }
            else if (fishes.GetModel(fishName) != null)
            {
                result = string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }
            else
            {
                IFish newFish;

                if (fishType == nameof(ReefFish))
                {
                    newFish = new ReefFish(fishName, points);
                }
                else if (fishType == nameof(PredatoryFish))
                {
                    newFish = new PredatoryFish(fishName, points);
                }
                else
                {
                    newFish = new DeepSeaFish(fishName, points);
                }

                fishes.AddModel(newFish);
                result = string.Format(OutputMessages.FishCreated, fishName);
            }

            return result.Trim();
        }
    }
}
