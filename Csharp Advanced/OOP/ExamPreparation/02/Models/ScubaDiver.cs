namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int oxygenLevel = 540;
        private const double oxyDecreaseIndex = 0.3;

        public ScubaDiver(string name)
            : base(name, oxygenLevel)
        {

        }

        public override void Miss(int timeToCatch)
        {
            int usedOxy = (int)Math.Round(timeToCatch * oxyDecreaseIndex);
            base.OxygenLevel -= usedOxy;
        }

        public override void RenewOxy()
        {
            base.OxygenLevel = oxygenLevel;
        }
    }
}
