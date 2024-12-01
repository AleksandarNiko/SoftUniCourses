using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository:IRepository<IClimber>
    {
        private HashSet<IClimber> all;
        public IReadOnlyCollection<IClimber> All { get=>all; }
        public void Add(IClimber model)
        {
            all.Add(model);
        }

        public IClimber Get(string name)
        {
            return all.FirstOrDefault(x => x.Name == name);
        }
    }
}
