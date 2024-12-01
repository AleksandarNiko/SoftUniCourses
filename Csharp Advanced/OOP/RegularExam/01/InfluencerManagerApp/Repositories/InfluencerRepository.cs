using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public class InfluencerRepository: IRepository<IInfluencer>
    {
        private List<IInfluencer> influencers=new List<IInfluencer>();
        public IReadOnlyCollection<IInfluencer> Models { get=>influencers.AsReadOnly(); }
        public void AddModel(IInfluencer model)
        {
            influencers.Add(model);
        }

        public bool RemoveModel(IInfluencer model)
        {
            return influencers.Remove(model);
        }

        public IInfluencer FindByName(string name)
        {
            return influencers.FirstOrDefault(x => x.Username == name);
        }
    }
}
