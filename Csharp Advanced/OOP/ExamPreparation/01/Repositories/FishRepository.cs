using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository: IRepository<IFish>
    {
        private List<IFish> models;

        public IReadOnlyCollection<IFish> Models
        {
            get
            {
                return models.AsReadOnly();
            }
        }

        public void AddModel(IFish model)
        {
            models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
