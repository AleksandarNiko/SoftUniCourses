using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Rogue:BaseHero
    {
        private const int roguePower = 80;
        public Rogue(string name) : base(name, roguePower)
        {
        }

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {this.Name} hit for {this.Power} damage";
        }
    }
}
