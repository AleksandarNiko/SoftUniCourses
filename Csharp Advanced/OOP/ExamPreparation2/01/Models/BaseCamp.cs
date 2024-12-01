using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp:IBaseCamp
    {
        private SortedSet<string> residents;
        public IReadOnlyCollection<string> Residents { get=>residents; }
        public BaseCamp() { }

        public void ArriveAtCamp(string climberName)
        {
            residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            residents.Remove(climberName);
        }

    }
}
