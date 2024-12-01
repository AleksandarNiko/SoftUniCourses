using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class MemberRepository : IRepository<ITeamMember>
    {
        private List<ITeamMember>models=new List<ITeamMember>();
        public IReadOnlyCollection<ITeamMember> Models {  get { return models.AsReadOnly(); } }

        public void Add(ITeamMember model)
        {  
            models.Add(model);
        }

        public ITeamMember TakeOne(string modelName)
        {
            if (models.Any())
            {
                return models.Where(x => x.Name == modelName).FirstOrDefault();
            }
            return null;
        }
    }
}
