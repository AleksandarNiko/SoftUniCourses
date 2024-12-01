using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Repositories
{
    public class CampaignRepository: IRepository<ICampaign>
    {
        private List<ICampaign> campaigns=new List<ICampaign>();
        public IReadOnlyCollection<ICampaign> Models { get=>campaigns.AsReadOnly(); }
        public void AddModel(ICampaign model)
        {
            campaigns.Add(model);
        }

        public bool RemoveModel(ICampaign model)
        {
            return campaigns.Remove(model);
        }

        public ICampaign FindByName(string name)
        {
            return campaigns.FirstOrDefault(x => x.Brand == name);
        }
    }
}
