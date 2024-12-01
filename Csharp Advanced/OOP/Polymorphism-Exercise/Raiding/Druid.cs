using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Druid:BaseHero
    {
        private const int druidPower = 80;
        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {Name} healed for {Power}";
        }

        public Druid(string name) : base(name, druidPower)
        {
        }
    }
}
