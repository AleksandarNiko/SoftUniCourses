using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository:IRepository<IPeak>
    {
        private HashSet<IPeak> all;
        public IReadOnlyCollection<IPeak> All { get=>all; }
        public void Add(IPeak model)
        {
            all.Add(model);
        }

        public IPeak Get(string name)
        {
            return all.FirstOrDefault(x => x.Name == name);
        }
    }
}
