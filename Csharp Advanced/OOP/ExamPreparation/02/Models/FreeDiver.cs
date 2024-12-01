namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int oxygenLevel = 120;
        private const double oxyDecreaseIndex = 0.6;

        public FreeDiver(string name)
            : base (name, oxygenLevel)
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
